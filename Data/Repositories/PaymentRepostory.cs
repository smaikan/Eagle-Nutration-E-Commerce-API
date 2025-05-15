using Core.Model;
using Core.Interfaces;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<Payment> CreatePaymentAsync(Payment payment)
        {
            await _context.Payment.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        
        public async Task<Payment> GetPaymentByOrderIdAsync(int Id)
        {
            return await _context.Payment
                .Include(p => p.Order) 
                .FirstOrDefaultAsync(p => p.OrderId == Id);
        }

        
        public async Task<List<Payment>> GetAllPaymentsAsync()
        {
            return await _context.Payment.ToListAsync();
        }

        

      
        public async Task<bool> DeletePaymentAsync(int id)
        {
            var payment = await _context.Payment.FindAsync(id);
            if (payment == null) return false;

            _context.Payment.Remove(payment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
