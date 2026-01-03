using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HotelRapidApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes = stream.ToArray();

            ByteArrayContent byteContent = new ByteArrayContent(bytes);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multiContent = new MultipartFormDataContent();
            multiContent.Add(byteContent, "file", file.FileName);
            var httpClient = new HttpClient();
            await httpClient.PostAsync("http://localhost:5196/api/FileProcess", multiContent);
            return View();
        }
    }
}
