using HotelRapidApi.WebUI.DTOs.BookingDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelRapidApi.WebUI.Controllers
{
    [AllowAnonymous]
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingDto createBookingDto)
        {
            createBookingDto.Status = "Onay Bekliyor";
            createBookingDto.City = string.IsNullOrWhiteSpace(createBookingDto.City)
               ? "Bilinmiyor"
               : createBookingDto.City;
            createBookingDto.Country = string.IsNullOrWhiteSpace(createBookingDto.Country)
                ? "Bilinmiyor"
                : createBookingDto.Country;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent=new StringContent(jsonData,Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:5196/api/Bookings", stringContent);
            return RedirectToAction("Index","Default");
        }
    }
}
