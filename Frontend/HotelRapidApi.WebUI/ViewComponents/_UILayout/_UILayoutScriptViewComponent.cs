using Microsoft.AspNetCore.Mvc;
namespace HotelRapidApi.WebUI.ViewComponents._UILayout
{
    public class _UILayoutScriptViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
