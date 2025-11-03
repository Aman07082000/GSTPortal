using Microsoft.AspNetCore.Mvc;
using GSTPortal.Data;
using GSTPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace GSTPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public SubscriptionController(ApplicationDbContext db) => _db = db;

        [HttpGet("tiers")]
        public async Task<IActionResult> GetTiers() =>
            Ok(await _db.SubscriptionTiers.ToListAsync());

        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe(SubscribeDto dto)
        {
            // Payment flow stub - in real app validate payment, webhook
            var payment = new Payment
            {
                UserId = dto.UserId,
                Amount = dto.Amount,
                Status = "Completed",
                GatewayReference = Guid.NewGuid().ToString()
            };
            _db.Payments.Add(payment);

            var user = await _db.Users.FindAsync(dto.UserId);
            if (user != null)
            {
                user.SubscriptionTierId = dto.TierId;
            }

            await _db.SaveChangesAsync();
            return Ok(new { payment.Id, payment.Status });
        }
    }

    public record SubscribeDto(string UserId, Guid TierId, decimal Amount);
}