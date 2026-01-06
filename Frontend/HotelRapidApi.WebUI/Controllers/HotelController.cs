using Microsoft.AspNetCore.Mvc;

namespace HotelRapidApi.WebUI.Controllers
{
    public class HotelController : Controller
    {
        // Tüm oteller (liste)
        public IActionResult Index()
        {
            return View();
        }

        // Detay sayfası
        public IActionResult Detail(int id)
        {
            ViewBag.HotelId = id;
            return View();
        }
    }
}
