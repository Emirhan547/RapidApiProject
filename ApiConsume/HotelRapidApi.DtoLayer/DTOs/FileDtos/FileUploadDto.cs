using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRapidApi.DtoLayer.DTOs.NewFolder
{
    public class FileUploadDto
    {
        public IFormFile File { get; set; }
    }
}
