using HotelRapidApi.WebUI.DTOs.ContactMessageDtos;
using HotelRapidApi.WebUI.DTOs.MessageCategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace HotelRapidApi.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5196/api/MessageCategory");

            List<ResultMessageCategoryDto> values = new();

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultMessageCategoryDto>>(jsonData)
                         ?? new List<ResultMessageCategoryDto>();
            }

            List<SelectListItem> values2 = values
                .Select(x => new SelectListItem
                {
                    Text = x.MessageCategoryName,
                    Value = x.Id.ToString()
                })
                .ToList();

            ViewBag.v = values2;

            return View();
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactMessageDto createContactDto)
        {
            createContactDto.Date = DateTime.Now;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent =
                new StringContent(jsonData, Encoding.UTF8, "application/json");

            await client.PostAsync(
                "http://localhost:5196/api/ContactMessages",
                stringContent
            );

            return RedirectToAction("Index", "Default");
        }
    }
}
