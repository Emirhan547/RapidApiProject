using HotelRapidApi.WebUI.DTOs.BookingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelRapidApi.WebUI.ViewComponents.Dashboard
{
    public class _DashboardLast6BookingsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DashboardLast6BookingsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:3523/api/Booking/Last6Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast6BookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
