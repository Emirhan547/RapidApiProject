namespace HotelRapidApi.WebUI.DTOs.RapidApiDtos
{
    public class PropertySearchListingDto
    {
        public string PropertyId { get; set; }

        public HeadingSectionDto HeadingSection { get; set; }

        public MediaSectionDto MediaSection { get; set; }

        public List<SummarySectionDto> SummarySections { get; set; }

    }
}
