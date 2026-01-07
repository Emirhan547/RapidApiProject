using Microsoft.AspNetCore.Mvc;
using HotelRapidApi.WebUI.DTOs.RapidApiDtos;
using HotelRapidApi.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace HotelRapidApi.WebUI.Controllers
{
    public class HotelController : Controller
    {

        public async Task<IActionResult> Index(
            string searchTerm,
            float? minScore,
            float? maxScore,
            int? minReviewCount,
            int? maxReviewCount,
            string currency,
            DateTime? checkinFrom,
            DateTime? checkoutTo,
            int page = 1)
        {

            var client = new HttpClient();

            var url = "https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id=-2092174&search_type=CITY&arrival_date=2026-01-07&departure_date=2026-01-15&adults=1&children_age=0%2C17&room_qty=1&page_number=1&units=metric&temperature_unit=c&languagecode=en-us&currency_code=TRY&location=TR";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("x-rapidapi-key", "047a17087bmsh5d1af7361331700p13e5fdjsne8c480915cd5");
            request.Headers.Add("x-rapidapi-host", "booking-com15.p.rapidapi.com");

            var response = await client.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(json);
                return View(new HotelListViewModel());
            }

            var root = JObject.Parse(json);
            var hotelArray =
                root["data"]?["hotels"] ??
                root["data"]?["result"];

            if (hotelArray == null)
            {
                Console.WriteLine("HOTEL ARRAY NULL");
                return View(new HotelListViewModel());
            }

            var allHotels = hotelArray
                .Select(item => new BookingApiResponseDto
                {
                    HotelId =
                        item["hotel_id"]?.Value<int>()
                        ?? item["id"]?.Value<int>()
                        ?? item["property"]?["id"]?.Value<int>()
                        ?? 0,
                    Name = item["property"]?["name"]?.ToString(),
                    ReviewScore = item["property"]?["reviewScore"]?.Value<float>() ?? 0,
                    ReviewScoreWord = item["property"]?["reviewScoreWord"]?.ToString(),
                    ReviewCount = item["property"]?["reviewCount"]?.Value<int>() ?? 0,
                    ImageUrl = item["property"]?["photoUrls"]?.FirstOrDefault()?.ToString()
                               ?? "https://placehold.co/600x400?text=Hotel",
                    CheckinDate = item["property"]?["checkinDate"]?.ToString(),
                    CheckoutDate = item["property"]?["checkoutDate"]?.ToString(),
                    Currency = item["property"]?["currency"]?.ToString()
                })
                .Take(50)
                .ToList();

            var hotels = allHotels;

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                hotels = hotels
                    .Where(hotel => (hotel.Name ?? string.Empty)
                        .Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (minScore.HasValue)
            {
                hotels = hotels.Where(hotel => hotel.ReviewScore >= minScore.Value).ToList();
            }

            if (maxScore.HasValue)
            {
                hotels = hotels.Where(hotel => hotel.ReviewScore <= maxScore.Value).ToList();
            }

            if (minReviewCount.HasValue)
            {
                hotels = hotels.Where(hotel => hotel.ReviewCount >= minReviewCount.Value).ToList();
            }

            if (maxReviewCount.HasValue)
            {
                hotels = hotels.Where(hotel => hotel.ReviewCount <= maxReviewCount.Value).ToList();
            }

            if (!string.IsNullOrWhiteSpace(currency))
            {
                hotels = hotels
                    .Where(hotel => string.Equals(hotel.Currency, currency, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (checkinFrom.HasValue)
            {
                hotels = hotels
                    .Where(hotel =>
                    {
                        var parsed = DateTime.TryParse(hotel.CheckinDate, out var checkinDate);
                        return parsed && checkinDate >= checkinFrom.Value;
                    })
                    .ToList();
            }

            if (checkoutTo.HasValue)
            {
                hotels = hotels
                    .Where(hotel =>
                    {
                        var parsed = DateTime.TryParse(hotel.CheckoutDate, out var checkoutDate);
                        return parsed && checkoutDate <= checkoutTo.Value;
                    })
                    .ToList();
            }

            var totalCount = hotels.Count;
            var pageSize = 10;
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            var currentPage = Math.Clamp(page, 1, Math.Max(totalPages, 1));

            var pagedHotels = hotels
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var viewModel = new HotelListViewModel
            {
                Hotels = pagedHotels,
                AvailableCurrencies = allHotels
                    .Select(hotel => hotel.Currency)
                    .Where(currencyValue => !string.IsNullOrWhiteSpace(currencyValue))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .OrderBy(currencyValue => currencyValue)
                    .ToList(),
                SearchTerm = searchTerm,
                MinScore = minScore,
                MaxScore = maxScore,
                MinReviewCount = minReviewCount,
                MaxReviewCount = maxReviewCount,
                Currency = currency,
                CheckinFrom = checkinFrom,
                CheckoutTo = checkoutTo,
                CurrentPage = currentPage,
                TotalPages = totalPages,
                TotalCount = totalCount,
                PageSize = pageSize
            };

            return View(viewModel);
        }

        // Detay sayfası
        public IActionResult Detail(int id)
        {
            ViewBag.HotelId = id;
            return View();
        }
    }
}