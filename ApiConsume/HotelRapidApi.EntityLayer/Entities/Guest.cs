using HotelRapidApi.EntityLayer.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.EntityLayer.Entities
{
    public class Guest : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
    }
}
