namespace APIHindi.Data
{
    public class DepartmentInfo
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Vision { get; set; } = string.Empty;
        public string Mission { get; set; } = string.Empty;
        public string ChairmanMessage { get; set; } = string.Empty;
        public DateTime LastUpdatedUtc { get; set; }
    }
}
