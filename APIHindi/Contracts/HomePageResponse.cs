namespace APIHindi.Contracts
{
    public class HomePageResponse
    {
        public string Title { get; set; } = string.Empty;
        public string Vision { get; set; } = string.Empty;
        public string Mission { get; set; } = string.Empty;
        public string ChairmanMessage { get; set; } = string.Empty;
        public DateTime LastUpdatedUtc { get; set; }
        public IEnumerable<BannerItem> Banners { get; set; } = Enumerable.Empty<BannerItem>();
        public IEnumerable<AnnouncementItem> Announcements { get; set; } = Enumerable.Empty<AnnouncementItem>();
        public IEnumerable<QuickLinkItem> QuickLinks { get; set; } = Enumerable.Empty<QuickLinkItem>();
    }

    public class BannerItem
    {
        public string Heading { get; set; } = string.Empty;
        public string SubHeading { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }

    public class AnnouncementItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string LinkUrl { get; set; } = string.Empty;
        public DateTime PublishDateUtc { get; set; }
        public bool IsImportant { get; set; }
    }

    public class QuickLinkItem
    {
        public string Label { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
