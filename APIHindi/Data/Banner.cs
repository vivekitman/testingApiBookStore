namespace APIHindi.Data
{
    public class Banner
    {
        public int Id { get; set; }
        public string Heading { get; set; } = string.Empty;
        public string SubHeading { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
