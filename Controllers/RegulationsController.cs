using Microsoft.AspNetCore.Mvc;
using GSTPortal.Data;
using GSTPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace GSTPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegulationsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public RegulationsController(ApplicationDbContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] DocumentType? type)
        {
            var q = _db.RegulationDocuments.AsQueryable();
            if (type.HasValue) q = q.Where(r => r.Type == type.Value);
            return Ok(await q.OrderByDescending(r => r.PublishedDate).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Upload(RegulationDocument doc)
        {
            _db.RegulationDocuments.Add(doc);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(List), new { id = doc.Id }, doc);
        }
    }
}