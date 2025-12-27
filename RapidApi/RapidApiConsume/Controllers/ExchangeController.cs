using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/meta/getExchangeRates?base_currency=TRY"),
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
                var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                if (values?.exchange_rates != null)
                {
                    return View(values.exchange_rates.ToList());
                }
                else
                {
                    // Handle the null case appropriately, e.g., return an empty list or an error view
                    return View(new List<ExchangeViewModel.Exchange_Rates>());
                }
            }
        }
    }
}
