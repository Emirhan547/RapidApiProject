using System.Globalization;
using System.Text.RegularExpressions;
using HotelRapidApi.WebUI.DTOs.RapidApiDtos;
using HotelRapidApi.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace HotelRapidApi.WebUI.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public HotelController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
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
            var client = _httpClientFactory.CreateClient();
            var apiKey = _configuration["RapidApi:Key"];
            var apiHost = _configuration["RapidApi:Host"];

            if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(apiHost))
            {
                Console.WriteLine("RapidAPI credentials are missing.");
                return View(new HotelListViewModel());
            }

            var url = "https://hotels-com6.p.rapidapi.com/hotels/search?locationId=6241295&checkinDate=2026-01-17&checkoutDate=2026-01-25&rooms=%5B%7B%22adults%22%3A%201%7D%5D";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("x-rapidapi-key", apiKey);
            request.Headers.Add("x-rapidapi-host", apiHost);

            var response = await client.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(json);
                return View(new HotelListViewModel());
            }

            var root = JObject.Parse(json);
            var hotelArray = root["data"]?["propertySearchListings"];

            if (hotelArray == null)
            {
                Console.WriteLine("HOTEL ARRAY NULL");
                return View(new HotelListViewModel());
            }

            var dateRangeToken = root["data"]?["criteria"]?["primary"]?["dateRange"];
            var checkinDate = BuildDateString(dateRangeToken?["checkInDate"]);
            var checkoutDate = BuildDateString(dateRangeToken?["checkOutDate"]);

            var allHotels = hotelArray
                .Select(item => MapHotel(item, checkinDate, checkoutDate))
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

        private static BookingApiResponseDto MapHotel(JToken item, string checkinDate, string checkoutDate)
        {
            var ratingToken = item["summarySections"]?.FirstOrDefault()?["guestRatingSectionV2"];
            var badgeText = ratingToken?["badge"]?["text"]?.ToString();
            var ratingText = ExtractRatingText(ratingToken) ?? badgeText;
            var priceText = ExtractPriceText(item["priceSection"]?["priceSummary"]);
            var currency = ExtractCurrency(priceText);

            return new BookingApiResponseDto
            {
                HotelId = ParseHotelId(item["propertyId"]?.ToString()),
                Name = item["headingSection"]?["heading"]?.ToString(),
                ReviewScore = ExtractScore(badgeText),
                ReviewScoreWord = ratingText,
                ReviewCount = ExtractReviewCount(ratingToken),
                ImageUrl = ExtractImageUrl(item["mediaSection"]?["gallery"]),
                PriceText = priceText,
                CheckinDate = checkinDate,
                CheckoutDate = checkoutDate,
                Currency = currency
            };
        }

        private static string ExtractImageUrl(JToken galleryToken)
        {
            return galleryToken?["media"]?.FirstOrDefault()?["media"]?["url"]?.ToString()
                   ?? "https://placehold.co/600x400?text=Hotel";
        }

        private static string ExtractPriceText(JToken priceSummaryToken)
        {
            return priceSummaryToken?["optionsV2"]?.FirstOrDefault()?["formattedDisplayPrice"]?.ToString()
                   ?? priceSummaryToken?["optionsV2"]?.FirstOrDefault()?["displayPrice"]?["formatted"]?.ToString();
        }

        private static string ExtractRatingText(JToken ratingToken)
        {
            var phraseParts = ratingToken?["phrases"]?.FirstOrDefault()?["phraseParts"];
            if (phraseParts == null)
            {
                return null;
            }

            var combined = string.Join(
                " ",
                phraseParts
                    .Select(part => part?["text"]?.ToString())
                    .Where(text => !string.IsNullOrWhiteSpace(text)));

            return string.IsNullOrWhiteSpace(combined) ? null : combined;
        }

        private static float ExtractScore(string badgeText)
        {
            if (string.IsNullOrWhiteSpace(badgeText))
            {
                return 0;
            }

            var match = Regex.Match(badgeText, @"\d+[.,]?\d*");
            if (!match.Success)
            {
                return 0;
            }

            var normalized = match.Value.Replace(',', '.');
            return float.TryParse(normalized, NumberStyles.Float, CultureInfo.InvariantCulture, out var score)
                ? score
                : 0;
        }

        private static int ExtractReviewCount(JToken ratingToken)
        {
            var phraseParts = ratingToken?["phrases"]?.FirstOrDefault()?["phraseParts"];
            if (phraseParts == null)
            {
                return 0;
            }

            var combined = string.Join(
                " ",
                phraseParts
                    .Select(part => part?["text"]?.ToString())
                    .Where(text => !string.IsNullOrWhiteSpace(text)));

            if (string.IsNullOrWhiteSpace(combined))
            {
                return 0;
            }

            var match = Regex.Match(combined, @"\d[\d.,]*");
            if (!match.Success)
            {
                return 0;
            }

            var digitsOnly = Regex.Replace(match.Value, @"\D", string.Empty);
            return int.TryParse(digitsOnly, out var count) ? count : 0;
        }

        private static string ExtractCurrency(string priceText)
        {
            if (string.IsNullOrWhiteSpace(priceText))
            {
                return null;
            }

            var codeMatch = Regex.Match(priceText, @"\b[A-Z]{3}\b");
            if (codeMatch.Success)
            {
                return codeMatch.Value;
            }

            var prefixMatch = Regex.Match(priceText, @"^[^\d]+");
            return prefixMatch.Success ? prefixMatch.Value.Trim() : null;
        }

        private static int ParseHotelId(string propertyId)
        {
            return int.TryParse(propertyId, out var id) ? id : 0;
        }

        private static string BuildDateString(JToken dateToken)
        {
            if (dateToken == null)
            {
                return null;
            }

            var year = dateToken["year"]?.Value<int>() ?? 0;
            var month = dateToken["month"]?.Value<int>() ?? 0;
            var day = dateToken["day"]?.Value<int>() ?? 0;

            if (year == 0 || month == 0 || day == 0)
            {
                return null;
            }

            return new DateTime(year, month, day).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
    }
}
