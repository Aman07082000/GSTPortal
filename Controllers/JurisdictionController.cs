using Microsoft.AspNetCore.Mvc;
using GSTPortal.Data;
using GSTPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace GSTPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JurisdictionController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public JurisdictionController(ApplicationDbContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _db.Jurisdictions.ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Create(Jurisdiction j)
        {
            _db.Jurisdictions.Add(j);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = j.Id }, j);
        }
    }
}