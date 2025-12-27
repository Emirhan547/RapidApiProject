using HotelRapidApi.WebUI.Models;

namespace HotelRapidApi.WebUI.Areas.Admin.Models.Staff
{
    public class StaffViewModel:BaseViewModel
    {
        public int StaffId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
