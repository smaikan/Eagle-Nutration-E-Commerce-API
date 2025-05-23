using Core.DTOs.OrderDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrderService
    {
        // Yeni sipariş oluşturma
        Task<OrderDTO> CreateOrderAsync(OrderCreateDTO orderCreateDto);

        // Sipariş ID'sine göre sipariş bilgisi al
        Task<OrderDTO> GetOrderByIdAsync(int id);

        // Kullanıcı ID'sine göre siparişleri al
        Task<List<OrderDTO>> GetOrdersByUserIdAsync(int userId);

        // Tüm siparişleri al
        Task<List<OrderDTO>> GetAllOrdersAsync();

        // Siparişi sil
        Task<bool> DeleteOrderAsync(int id);

        // Sipariş durumunu güncelle
        Task<bool> UpdateOrderStatusAsync(int orderId, string newStatus);
    }
}
