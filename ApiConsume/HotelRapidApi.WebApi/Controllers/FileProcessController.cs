using HotelRapidApi.DtoLayer.DTOs.NewFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelRapidApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileProcessController : ControllerBase
    {
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadFile([FromForm] FileUploadDto model)
        {
            if (model.File == null || model.File.Length == 0)
                return BadRequest("Dosya seçilmedi");

            var fileName = Guid.NewGuid() + Path.GetExtension(model.File.FileName);

            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "files",
                fileName
            );

            using var stream = new FileStream(path, FileMode.Create);
            await model.File.CopyToAsync(stream);

            return Created("", fileName);
        }
    }
}
