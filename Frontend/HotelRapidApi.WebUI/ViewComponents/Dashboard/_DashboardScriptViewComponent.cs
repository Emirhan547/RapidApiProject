using Microsoft.AspNetCore.Mvc;

namespace HotelRapidApi.WebUI.ViewComponents.Dashboard
{
    public class _DashboardScriptViewComponent  :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
