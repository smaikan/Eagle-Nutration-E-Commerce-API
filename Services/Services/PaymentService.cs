using Services.Interfaces;
using Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Services.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        
        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            return await _paymentRepository.CreatePaymentAsync(payment);
        }

        public async Task<Payment> GetPaymentByOrderIdAsync(int orderId)
        {
            return await _paymentRepository.GetPaymentByOrderIdAsync(orderId);
        }

        public async Task<List<Payment>> GetAllPaymentsAsync()
        {
            return await _paymentRepository.GetAllPaymentsAsync();
        }
        

        public async Task<bool> DeletePaymentAsync(int id)
        {
            return await _paymentRepository.DeletePaymentAsync(id);
        }
    }
}
