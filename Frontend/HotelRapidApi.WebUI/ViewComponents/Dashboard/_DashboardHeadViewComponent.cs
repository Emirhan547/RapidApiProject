using Microsoft.AspNetCore.Mvc;

namespace HotelRapidApi.WebUI.ViewComponents.Dashboard
{
    public class _DashboardHeadViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
