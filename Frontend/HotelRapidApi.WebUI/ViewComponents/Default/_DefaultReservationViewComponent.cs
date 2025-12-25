using Microsoft.AspNetCore.Mvc;

namespace HotelRapidApi.WebUI.ViewComponents.Default
{
    public class _DefaultReservationViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
