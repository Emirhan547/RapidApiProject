using Microsoft.AspNetCore.Mvc;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query=man"),
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

            }
            return View();
        }
    }
}
