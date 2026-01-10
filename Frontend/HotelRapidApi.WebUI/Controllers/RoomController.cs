using HotelRapidApi.WebUI.DTOs.RoomDtos;
using HotelRapidApi.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelRapidApi.WebUI.Controllers
{
    [AllowAnonymous]
    public class RoomController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RoomController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(string search, int? minPrice, int? maxPrice, int? bedCount, int? bathCount, bool? wifiOnly, string sort)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5196/api/Rooms");
            var roomList = new List<ResultRoomDto>();

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                roomList = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData) ?? new List<ResultRoomDto>();
            }

            var viewModel = new RoomListViewModel
            {
                Search = search,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                BedCount = bedCount,
                BathCount = bathCount,
                WifiOnly = wifiOnly ?? false,
                Sort = sort,
                AvailableBedCounts = roomList.Select(x => x.BedCount).Distinct().OrderBy(x => x).ToList(),
                AvailableBathCounts = roomList.Select(x => x.BathCount).Distinct().OrderBy(x => x).ToList(),
                AvailableMinPrice = roomList.Any() ? roomList.Min(x => x.Price) : null,
                AvailableMaxPrice = roomList.Any() ? roomList.Max(x => x.Price) : null
            };

            IEnumerable<ResultRoomDto> filteredRooms = roomList;

            if (!string.IsNullOrWhiteSpace(search))
            {
                filteredRooms = filteredRooms.Where(x =>
                    (!string.IsNullOrWhiteSpace(x.Title) && x.Title.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrWhiteSpace(x.Description) && x.Description.Contains(search, StringComparison.OrdinalIgnoreCase)));
            }

            if (minPrice.HasValue)
            {
                filteredRooms = filteredRooms.Where(x => x.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                filteredRooms = filteredRooms.Where(x => x.Price <= maxPrice.Value);
            }

            if (bedCount.HasValue)
            {
                filteredRooms = filteredRooms.Where(x => x.BedCount >= bedCount.Value);
            }

            if (bathCount.HasValue)
            {
                filteredRooms = filteredRooms.Where(x => x.BathCount >= bathCount.Value);
            }

            if (wifiOnly == true)
            {
                filteredRooms = filteredRooms.Where(x =>
                    !string.IsNullOrWhiteSpace(x.Wifi) &&
                    (x.Wifi.Contains("var", StringComparison.OrdinalIgnoreCase) ||
                     x.Wifi.Contains("wifi", StringComparison.OrdinalIgnoreCase) ||
                     x.Wifi.Contains("free", StringComparison.OrdinalIgnoreCase) ||
                     x.Wifi.Contains("ücretsiz", StringComparison.OrdinalIgnoreCase) ||
                     x.Wifi.Contains("yes", StringComparison.OrdinalIgnoreCase)));
            }

            filteredRooms = sort switch
            {
                "price_desc" => filteredRooms.OrderByDescending(x => x.Price),
                "price_asc" => filteredRooms.OrderBy(x => x.Price),
                "bed_desc" => filteredRooms.OrderByDescending(x => x.BedCount),
                "bed_asc" => filteredRooms.OrderBy(x => x.BedCount),
                "title" => filteredRooms.OrderBy(x => x.Title),
                _ => filteredRooms.OrderByDescending(x => x.Id)
            };

            viewModel.Rooms = filteredRooms.ToList();

            return View(viewModel);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5196/api/Rooms/{id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                ViewBag.ErrorMessage = "Oda detayı bulunamadı.";
                return View(new ResultRoomDto());
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var room = JsonConvert.DeserializeObject<ResultRoomDto>(jsonData);

            if (room == null)
            {
                ViewBag.ErrorMessage = "Oda detayı bulunamadı.";
                return View(new ResultRoomDto());
            }

            return View(room);
        }
    }
}