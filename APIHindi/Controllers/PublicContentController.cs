using APIHindi.Contracts;
using APIHindi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIHindi.Controllers
{
    [ApiController]
    [Route("api/public")]
    public class PublicContentController : ControllerBase
    {
        private readonly DatabaseContext _db;

        public PublicContentController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet("home")]
        public async Task<ActionResult<HomePageResponse>> GetHomePageAsync()
        {
            var info = await _db.DepartmentInfos.AsNoTracking().FirstOrDefaultAsync();
            if (info is null)
            {
                return NotFound("Department profile is not configured.");
            }

            var response = new HomePageResponse
            {
                Title = info.Title,
                Vision = info.Vision,
                Mission = info.Mission,
                ChairmanMessage = info.ChairmanMessage,
                LastUpdatedUtc = info.LastUpdatedUtc,
                Banners = await _db.Banners
                    .AsNoTracking()
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.DisplayOrder)
                    .Select(x => new BannerItem
                    {
                        Heading = x.Heading,
                        SubHeading = x.SubHeading,
                        ImageUrl = x.ImageUrl
                    })
                    .ToListAsync(),
                Announcements = await _db.Announcements
                    .AsNoTracking()
                    .OrderByDescending(x => x.PublishDateUtc)
                    .Take(8)
                    .Select(x => new AnnouncementItem
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Category = x.Category,
                        LinkUrl = x.LinkUrl,
                        PublishDateUtc = x.PublishDateUtc,
                        IsImportant = x.IsImportant
                    })
                    .ToListAsync(),
                QuickLinks = await _db.QuickLinks
                    .AsNoTracking()
                    .OrderBy(x => x.SortOrder)
                    .Select(x => new QuickLinkItem
                    {
                        Label = x.Label,
                        Url = x.Url
                    })
                    .ToListAsync()
            };

            return Ok(response);
        }
    }
}
