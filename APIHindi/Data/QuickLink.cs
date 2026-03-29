namespace APIHindi.Data
{
    public class QuickLink
    {
        public int Id { get; set; }
        public string Label { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public int SortOrder { get; set; }
    }
}
