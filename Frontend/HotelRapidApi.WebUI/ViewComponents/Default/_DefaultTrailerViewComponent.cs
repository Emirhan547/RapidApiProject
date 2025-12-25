using Microsoft.AspNetCore.Mvc;
namespace HotelRapidApi.WebUI.ViewComponents.Default
{
    public class _DefaultTrailerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
