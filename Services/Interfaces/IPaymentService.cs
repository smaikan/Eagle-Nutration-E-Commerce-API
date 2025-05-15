using Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPaymentService
    {
        Task<Payment> CreatePaymentAsync(Payment payment);  // Ödeme oluşturma
        Task<Payment> GetPaymentByOrderIdAsync(int orderId);  // Sipariş ID'sine göre ödeme
        Task<List<Payment>> GetAllPaymentsAsync();  // Tüm ödemeleri al
        Task<bool> DeletePaymentAsync(int id);  // Ödeme silme
    }
}
