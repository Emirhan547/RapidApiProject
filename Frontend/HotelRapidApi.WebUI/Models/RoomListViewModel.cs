using HotelRapidApi.WebUI.DTOs.RoomDtos;

namespace HotelRapidApi.WebUI.Models
{
    public class RoomListViewModel
    {
        public List<ResultRoomDto> Rooms { get; set; } = new();
        public string Search { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? BedCount { get; set; }
        public int? BathCount { get; set; }
        public bool WifiOnly { get; set; }
        public string Sort { get; set; }
        public int? AvailableMinPrice { get; set; }
        public int? AvailableMaxPrice { get; set; }
        public List<int> AvailableBedCounts { get; set; } = new();
        public List<int> AvailableBathCounts { get; set; } = new();
    }
}