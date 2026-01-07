using HotelRapidApi.WebUI.DTOs.RapidApiDtos;

namespace HotelRapidApi.WebUI.Models
{
    public class HotelListViewModel
    {
        public List<BookingApiResponseDto> Hotels { get; set; } = new();
        public List<string> AvailableCurrencies { get; set; } = new();

        public string SearchTerm { get; set; }
        public float? MinScore { get; set; }
        public float? MaxScore { get; set; }
        public int? MinReviewCount { get; set; }
        public int? MaxReviewCount { get; set; }
        public string Currency { get; set; }
        public DateTime? CheckinFrom { get; set; }
        public DateTime? CheckoutTo { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
    }
}