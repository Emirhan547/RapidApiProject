namespace HotelRapidApi.WebUI.DTOs.ContactMessageDtos
{
    public class ResultContactMessageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
