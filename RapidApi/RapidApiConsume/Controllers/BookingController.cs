using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class BookingController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id=-1456928&search_type=CITY&arrival_date=2025-12-27&departure_date=2026-01-01&adults=1&children_age=0%2C17&room_qty=1&page_number=1&units=metric&temperature_unit=c&languagecode=en-us&location=US"),
                Headers =
                {
                    { "x-rapidapi-key", "047a17087bmsh5d1af7361331700p13e5fdjsne8c480915cd5" },
                    { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BookingApiViewModel>(body);
                if (values?.property1 != null)
                {
                    return View(values.property1.ToList());
                }
                else
                {
                    return View(new List<BookingApiViewModel.Property1>());
                }
            }
        }
    }
}
