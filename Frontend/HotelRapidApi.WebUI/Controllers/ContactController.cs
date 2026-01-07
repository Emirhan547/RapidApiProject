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

        // 🔹 ORTAK METOT → KATEGORİLERİ YÜKLER
        private async Task LoadMessageCategories()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5196/api/MessageCategory");

            var values = new List<ResultMessageCategoryDto>();

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultMessageCategoryDto>>(jsonData)
                         ?? new List<ResultMessageCategoryDto>();
            }

            ViewBag.v = values.Select(x => new SelectListItem
            {
                Text = x.MessageCategoryName,
                Value = x.Id.ToString()
            }).ToList();
        }

        // 🔹 SAYFA (FORM)
        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            await LoadMessageCategories();
            return View();
        }

        // 🔹 FORM POST
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactMessageDto createContactDto)
        {
            if (!ModelState.IsValid)
            {
                await LoadMessageCategories();
                return View(createContactDto);
            }

            createContactDto.Date = DateTime.Now;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            await client.PostAsync(
                "http://localhost:5196/api/ContactMessages",
                stringContent
            );

            return RedirectToAction("Index", "Default");
        }
    }
}
