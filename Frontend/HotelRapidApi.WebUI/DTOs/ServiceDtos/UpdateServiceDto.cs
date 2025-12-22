namespace HotelRapidApi.WebUI.DTOs.ServiceDtos
{
    public class UpdateServiceDto
    {
        public int Id { get; set; }
        public string? ServiceIcon { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
