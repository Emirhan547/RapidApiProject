using Microsoft.AspNetCore.Mvc;

namespace HotelRapidApi.WebUI.ViewComponents._AdminLayout
{
    public class _AdminLayoutPreloaderViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
