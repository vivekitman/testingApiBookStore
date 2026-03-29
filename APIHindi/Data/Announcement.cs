namespace APIHindi.Data
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string LinkUrl { get; set; } = string.Empty;
        public DateTime PublishDateUtc { get; set; }
        public bool IsImportant { get; set; }
    }
}
