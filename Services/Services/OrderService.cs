using AutoMapper;
using Core.DTOs.OrderDTOs;
using Core.Interfaces;
using Core.Model;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;  

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        
        public async Task<OrderDTO> CreateOrderAsync(OrderCreateDTO orderCreateDto)
        {
            var order = _mapper.Map<Order>(orderCreateDto);  
            var createdOrder = await _orderRepository.CreateOrderAsync(order);
            return _mapper.Map<OrderDTO>(createdOrder);  
        }

        
        public async Task<OrderDTO> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null)
            {
                throw new Exception("Sipariş bulunamadı.");
            }
            return _mapper.Map<OrderDTO>(order);  
        }

        
        public async Task<List<OrderDTO>> GetOrdersByUserIdAsync(int userId)
        {
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
            return _mapper.Map<List<OrderDTO>>(orders);  
        }

        
        public async Task<List<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return _mapper.Map<List<OrderDTO>>(orders);  
        }

        
        public async Task<bool> DeleteOrderAsync(int id)
        {
            return await _orderRepository.DeleteOrderAsync(id);
        }

       
        public async Task<bool> UpdateOrderStatusAsync(int orderId, string newStatus)
        {
            return await _orderRepository.UpdateOrderStatusAsync(orderId, newStatus);
        }

        

    }
}
