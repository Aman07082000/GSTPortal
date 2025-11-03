using Microsoft.AspNetCore.Mvc;
using GSTPortal.Data;
using GSTPortal.Models;

namespace GSTPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GrievanceController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public GrievanceController(ApplicationDbContext db) => _db = db;

        [HttpPost]
        public async Task<IActionResult> Create(Grievance g)
        {
            _db.Grievances.Add(g);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), new { id = g.Id }, g);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var g = await _db.Grievances.FindAsync(id);
            if (g == null) return NotFound();
            return Ok(g);
        }
    }
}