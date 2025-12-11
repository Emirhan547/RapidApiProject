using Microsoft.AspNetCore.Mvc;

namespace HotelRapidApi.WebUI.ViewComponents._AdminLayout
{
    public class _AdminLayoutSidebarViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
