using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.DtoLayer.DTOs.MessageCategoryDtos
{
    public class UpdateMessageCategoryDto
    {
        public int Id { get; set; }
        public string MessageCategoryName { get; set; }
    }
}
