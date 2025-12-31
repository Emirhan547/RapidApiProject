using HotelRapidApi.EntityLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.EntityLayer.Entities
{
    public class MessageCategory : BaseEntity
    {
        public string MessageCategoryName { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
