using Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);  // Sipariş ekleme
        Task<Order> GetOrderByIdAsync(int id);     // ID ile sipariş getirme
        Task<List<Order>> GetAllOrdersAsync();     // Tüm siparişleri getirme
        Task<List<Order>> GetOrdersByUserIdAsync(int userId); // Kullanıcı ID'sine göre siparişler
        Task<bool> DeleteOrderAsync(int id);       // Sipariş silme
        Task<bool> UpdateOrderStatusAsync(int orderId, string newStatus); // Sipariş durumunu güncelleme
    }
}
