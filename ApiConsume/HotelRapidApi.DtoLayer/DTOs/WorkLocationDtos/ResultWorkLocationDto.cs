using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.DtoLayer.DTOs.WorkLocationDtos
{
    public class ResultWorkLocationDto
    {
        public int Id { get; set; }
        public string WorkLocationName { get; set; }
        public string WorkLocationCity { get; set; }
    }
}
