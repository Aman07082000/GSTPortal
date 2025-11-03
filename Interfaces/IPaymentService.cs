using System;
namespace GSTPortal.Interfaces
{
	public interface IPaymentService
	{
        Task<object> CreatePaymentAsync(string userId, decimal amount);
    }
}

