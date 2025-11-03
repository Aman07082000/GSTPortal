using Microsoft.AspNetCore.Mvc;
using GSTPortal.Services;
using GSTPortal.Interfaces;
namespace GSTPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _payments;
        public PaymentController(IPaymentService payments) => _payments = payments;

        [HttpPost("create")]
        public async Task<IActionResult> CreatePayment(PaymentCreateDto dto)
        {
            // In production: call gateway SDK (Razorpay/Stripe), create order, return client token
            var result = await _payments.CreatePaymentAsync(dto.UserId, dto.Amount);
            return Ok(result);
        }
    }

    public record PaymentCreateDto(string UserId, decimal Amount);
}