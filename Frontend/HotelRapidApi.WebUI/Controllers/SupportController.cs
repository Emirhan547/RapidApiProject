using Microsoft.AspNetCore.Mvc;


    using Microsoft.AspNetCore.Authorization;

    using Microsoft.AspNetCore.Mvc.Rendering;
    using Newtonsoft.Json;
using HotelRapidApi.WebUI.DTOs.MessageCategoryDtos;

namespace HotelRapidApi.WebUI.Controllers
    {
        [AllowAnonymous]
        public class SupportController : Controller
        {
            private readonly IHttpClientFactory _httpClientFactory;

            public SupportController(IHttpClientFactory httpClientFactory)
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

                List<SelectListItem> categories = values
                    .Select(x => new SelectListItem
                    {
                        Text = x.MessageCategoryName,
                        Value = x.Id.ToString()
                    })
                    .ToList();

                ViewBag.v = categories;

                return View();
            }
        }
    }
