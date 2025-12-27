using HotelRapidApi.WebUI.DTOs.BookingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelRapidApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient(); 
            var responseMessage= await client.GetAsync("http://localhost:5196/api/Bookings");
            if(responseMessage.IsSuccessStatusCode)
            {
               var jsondata= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsondata);
                return View(values);
            }
            return View();
        }
    }
}
