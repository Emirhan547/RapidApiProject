namespace RapidApiConsume.Models
{
    public class BookingApiViewModel
    {
        public Data data { get; set; }
        public Meta meta { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
    }

    public class Data
    {
        public PropertySearchListing[] propertySearchListings { get; set; }
        public Pagination pagination { get; set; }
    }

    public class PropertySearchListing
    {
        public string propertyId { get; set; }
        public HeadingSection headingSection { get; set; }
        public SummarySection[] summarySections { get; set; }
        public MediaSection mediaSection { get; set; }
        public PriceSection priceSection { get; set; }
    }

    public class HeadingSection
    {
        public string heading { get; set; }
    }

    public class SummarySection
    {
        public GuestRatingSectionV2 guestRatingSectionV2 { get; set; }
    }

    public class GuestRatingSectionV2
    {
        public Badge badge { get; set; }
        public Phrase[] phrases { get; set; }
    }

    public class Badge
    {
        public string text { get; set; }
    }

    public class Phrase
    {
        public PhrasePart[] phraseParts { get; set; }
    }

    public class PhrasePart
    {
        public string text { get; set; }
    }

    public class MediaSection
    {
        public Gallery gallery { get; set; }
    }

    public class Gallery
    {
        public Medium[] media { get; set; }
    }

    public class Medium
    {
        public Media media { get; set; }
    }

    public class Media
    {
        public string url { get; set; }
    }

    public class PriceSection
    {
        public PriceSummary priceSummary { get; set; }
    }

    public class PriceSummary
    {
        public OptionsV2[] optionsV2 { get; set; }
    }

    public class OptionsV2
    {
        public string formattedDisplayPrice { get; set; }
        public DisplayPrice displayPrice { get; set; }
    }

    public class DisplayPrice
    {
        public string formatted { get; set; }
    }

    public class Pagination
    {
        public SubSets subSets { get; set; }
    }

    public class SubSets
    {
        public NextSubSet nextSubSet { get; set; }
    }

    public class NextSubSet
    {
        public int size { get; set; }
        public int startingIndex { get; set; }
    }

    public class Meta
    {
        public int currentPage { get; set; }
        public int limit { get; set; }
        public int totalRecords { get; set; }
        public int totalPage { get; set; }
    }
}
