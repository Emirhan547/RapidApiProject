using HotelRapidApi.WebUI.DTOs.AppUserDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelRapidApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserListWithWorkLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserListWithWorkLocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> UserList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5196/api/AppUsers/WithWorkLocation");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAppUserWithWorkLocationDto>>(jsondata);
                return View(values ?? new List<ResultAppUserWithWorkLocationDto>());
            }
            return View(new List<ResultAppUserWithWorkLocationDto>());
        }
    }
}
