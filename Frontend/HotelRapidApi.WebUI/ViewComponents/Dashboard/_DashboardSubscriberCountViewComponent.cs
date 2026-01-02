using Microsoft.AspNetCore.Mvc;

namespace HotelRapidApi.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscriberCountViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
