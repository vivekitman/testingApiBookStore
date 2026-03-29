using APIHindi.Contracts;
using APIHindi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIHindi.Controllers
{
    [ApiController]
    [Route("api/announcements")]
    public class AnnouncementsController : ControllerBase
    {
        private readonly DatabaseContext _db;

        public AnnouncementsController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnnouncementItem>>> GetAsync([FromQuery] string? category)
        {
            var query = _db.Announcements.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(x => x.Category == category);
            }

            var result = await query
                .OrderByDescending(x => x.PublishDateUtc)
                .Select(x => new AnnouncementItem
                {
                    Id = x.Id,
                    Title = x.Title,
                    Category = x.Category,
                    LinkUrl = x.LinkUrl,
                    PublishDateUtc = x.PublishDateUtc,
                    IsImportant = x.IsImportant
                })
                .ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<AnnouncementItem>> CreateAsync([FromBody] CreateAnnouncementRequest request)
        {
            var entity = new Announcement
            {
                Title = request.Title,
                Category = request.Category,
                LinkUrl = request.LinkUrl,
                PublishDateUtc = request.PublishDateUtc,
                IsImportant = request.IsImportant
            };

            _db.Announcements.Add(entity);
            await _db.SaveChangesAsync();

            var response = new AnnouncementItem
            {
                Id = entity.Id,
                Title = entity.Title,
                Category = entity.Category,
                LinkUrl = entity.LinkUrl,
                PublishDateUtc = entity.PublishDateUtc,
                IsImportant = entity.IsImportant
            };

            return CreatedAtAction(nameof(GetAsync), new { id = entity.Id }, response);
        }
    }
}
