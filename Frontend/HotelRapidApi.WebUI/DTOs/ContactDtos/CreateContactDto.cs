namespace HotelRapidApi.WebUI.DTOs.ContactDtos
{
    public class CreateContactDto
    {
        public string Name { get; set; }
        public string mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
