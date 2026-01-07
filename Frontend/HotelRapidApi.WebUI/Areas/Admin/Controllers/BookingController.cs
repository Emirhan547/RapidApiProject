using HotelRapidApi.WebUI.DTOs.BookingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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
            var responseMessage = await client.GetAsync("http://localhost:5196/api/Bookings");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values ?? new List<ResultBookingDto>());
            }
            return View(new List<ResultBookingDto>());
        }

        public async Task<IActionResult> ApprovedReservation2(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"http://localhost:5196/api/Bookings/BookingAproved?id={id}");
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> CancelReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"http://localhost:5196/api/Bookings/BookingCancel?id={id}");
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> WaitReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"http://localhost:5196/api/Bookings/BookingWait?id={id}");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5196/api/Bookings/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(values);
            }
            return View(new UpdateBookingDto());
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5196/api/Booking/UpdateBooking/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
