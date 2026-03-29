using Microsoft.EntityFrameworkCore;

namespace APIHindi.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<DepartmentInfo> DepartmentInfos => Set<DepartmentInfo>();
        public DbSet<Banner> Banners => Set<Banner>();
        public DbSet<Announcement> Announcements => Set<Announcement>();
        public DbSet<QuickLink> QuickLinks => Set<QuickLink>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentInfo>().HasData(
                new DepartmentInfo
                {
                    Id = 1,
                    Title = "National Commission for Backward Classes",
                    Vision = "Social justice, constitutional safeguards and equitable development.",
                    Mission = "Deliver transparent and accountable services to citizens through a digital-first platform.",
                    ChairmanMessage = "Our mission is to strengthen constitutional rights, monitor implementation, and improve access to welfare schemes.",
                    LastUpdatedUtc = new DateTime(2026, 3, 1, 0, 0, 0, DateTimeKind.Utc)
                });

            modelBuilder.Entity<Banner>().HasData(
                new Banner { Id = 1, Heading = "Empowering Backward Classes", SubHeading = "Digital services for transparency and inclusion", ImageUrl = "/assets/banner-1.jpg", DisplayOrder = 1, IsActive = true },
                new Banner { Id = 2, Heading = "Citizen Centric Platform", SubHeading = "Track notices, circulars and tenders online", ImageUrl = "/assets/banner-2.jpg", DisplayOrder = 2, IsActive = true });

            modelBuilder.Entity<Announcement>().HasData(
                new Announcement { Id = 1, Title = "Public Notice for Scholarship Scheme", Category = "Notice", LinkUrl = "https://example.org/notice/scholarship", PublishDateUtc = new DateTime(2026, 2, 10, 0, 0, 0, DateTimeKind.Utc), IsImportant = true },
                new Announcement { Id = 2, Title = "Tender: IT Infrastructure Modernization", Category = "Tender", LinkUrl = "https://example.org/tender/it-infra", PublishDateUtc = new DateTime(2026, 2, 22, 0, 0, 0, DateTimeKind.Utc), IsImportant = false },
                new Announcement { Id = 3, Title = "Circular: Grievance Redressal Timeline", Category = "Circular", LinkUrl = "https://example.org/circular/grievance", PublishDateUtc = new DateTime(2026, 3, 5, 0, 0, 0, DateTimeKind.Utc), IsImportant = true });

            modelBuilder.Entity<QuickLink>().HasData(
                new QuickLink { Id = 1, Label = "Acts & Rules", Url = "https://example.org/acts", SortOrder = 1 },
                new QuickLink { Id = 2, Label = "Recruitment", Url = "https://example.org/recruitment", SortOrder = 2 },
                new QuickLink { Id = 3, Label = "Contact Us", Url = "https://example.org/contact", SortOrder = 3 });
        }
    }
}
