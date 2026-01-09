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
                RequestUri = new Uri("https://hotels-com6.p.rapidapi.com/hotels/search?locationId=6241295&checkinDate=2026-01-17&checkoutDate=2026-01-25&rooms=%5B%7B%22adults%22%3A%201%7D%5D"),
                Headers =
                {
                    { "x-rapidapi-key", "867d760a88msh85865aa894d49d4p1a89b4jsn7c3d8f0c5eb6" },
                    { "x-rapidapi-host", "hotels-com6.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BookingApiViewModel>(body);
                var listings = values?.data?.propertySearchListings?.ToList() ?? new List<PropertySearchListing>();
                return View(listings);
            }
        }
    }
}
