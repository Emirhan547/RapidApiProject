using Microsoft.AspNetCore.Mvc;

namespace HotelRapidApi.WebUI.ViewComponents.Default
{
    public class _DefaultSliderViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
