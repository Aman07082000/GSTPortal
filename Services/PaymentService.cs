using System.Threading.Tasks;
using GSTPortal.Interfaces;

namespace GSTPortal.Services
{
    public class PaymentService : IPaymentService
    {
        public async Task<object> CreatePaymentAsync(string userId, decimal amount)
        {
            // stub: replace with Razorpay / Stripe SDK integration
            await Task.Delay(20);
            return new { OrderId = System.Guid.NewGuid().ToString(), Amount = amount, Status = "Created" };
        }
    }
}