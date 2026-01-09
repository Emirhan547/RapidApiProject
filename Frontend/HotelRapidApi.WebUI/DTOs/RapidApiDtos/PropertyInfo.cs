namespace HotelRapidApi.WebUI.DTOs.RapidApiDtos
{
    public class PropertyInfo
    {
        public string PropertyId { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public Summary Summary { get; set; }
        public List<Image> Images { get; set; }
        public ReviewInfo ReviewInfo { get; set; }
    }
}
