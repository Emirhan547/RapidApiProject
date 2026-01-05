using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.DtoLayer.DTOs.ContactDtos
{
    public class UpdateContactDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

        public int MessageCategoryId { get; set; }
        public string MessageCategoryName { get; set; }
    }
}
