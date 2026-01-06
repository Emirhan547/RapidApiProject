using HotelRapidApi.WebUI.DTOs.RapidApiDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HotelRapidApi.WebUI.ViewComponents.Default
{
    public class _DefaultRapidApiHotelsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
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
                return View(new List<BookingApiResponseDto>());
            }

            // 🔥 JSON'u güvenli parse ediyoruz
            var root = JObject.Parse(json);

            // hotels varsa onu al, yoksa result al
            var hotelArray =
                root["data"]?["hotels"] ??
                root["data"]?["result"];

            if (hotelArray == null)
            {
                Console.WriteLine("HOTEL ARRAY NULL");
                return View(new List<BookingApiResponseDto>());
            }

            var hotels = hotelArray
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
     .ToList();


            return View(hotels);
        }
    }
}
