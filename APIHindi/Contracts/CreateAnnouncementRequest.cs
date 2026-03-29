using System.ComponentModel.DataAnnotations;

namespace APIHindi.Contracts
{
    public class CreateAnnouncementRequest
    {
        [Required]
        [MaxLength(160)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(40)]
        public string Category { get; set; } = string.Empty;

        [Required]
        [Url]
        public string LinkUrl { get; set; } = string.Empty;

        public DateTime PublishDateUtc { get; set; } = DateTime.UtcNow;
        public bool IsImportant { get; set; }
    }
}
