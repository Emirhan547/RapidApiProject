using System.Collections.Generic;

namespace HotelRapidApi.WebUI.DTOs.RapidApiDtos
{
    public class HotelDetailDto
    {

        public string HotelId { get; set; }
        public string Name { get; set; }
        public float ReviewScore { get; set; }
        public string ReviewScoreWord { get; set; }
        public int ReviewCount { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public List<string> PhotoUrls { get; set; } = new();
    }
}