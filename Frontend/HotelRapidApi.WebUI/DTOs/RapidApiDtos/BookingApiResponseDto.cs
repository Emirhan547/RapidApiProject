namespace HotelRapidApi.WebUI.DTOs.RapidApiDtos
{
    public class BookingApiResponseDto
    {
        public string HotelId { get; set; }
        public string Name { get; set; }
        public float ReviewScore { get; set; }
        public string ReviewScoreWord { get; set; }
        public int ReviewCount { get; set; }
        public string ImageUrl { get; set; }
        public string CheckinDate { get; set; }
        public string CheckoutDate { get; set; }
        public string Currency { get; set; }

    }
}