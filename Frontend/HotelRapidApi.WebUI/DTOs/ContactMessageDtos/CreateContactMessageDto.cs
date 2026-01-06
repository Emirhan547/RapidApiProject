

namespace HotelRapidApi.WebUI.DTOs.ContactMessageDtos
{
    public class CreateContactMessageDto
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int MessageCategoryId { get; set; }

    }
}
