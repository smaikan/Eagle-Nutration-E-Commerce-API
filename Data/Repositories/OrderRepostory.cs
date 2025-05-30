﻿using Core.Interfaces;
using Core.Model;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

       
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

       
        public async Task<Order> CreateOrderAsync(Order order)
        {
            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;  
        }

        
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Order
                .Include(o => o.OrderDetails) 
                .Include(o => o.User)          
                .FirstOrDefaultAsync(o => o.OrderId == id);  
        }

       
        public async Task<List<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _context.Order
                .Where(o => o.UserId == userId)  
                .Include(o => o.OrderDetails)    
                .Include(o => o.User)            
                .ToListAsync();
        }

        
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Order
                .Include(o => o.OrderDetails)  
                .Include(o => o.User)         
                .ToListAsync();
        }

        

        
        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order == null) return false;

            _context.Order.Remove(order);  
            await _context.SaveChangesAsync();
            return true;
        }

     
        public async Task<bool> UpdateOrderStatusAsync(int orderId, string newStatus)
        {
            var order = await _context.Order.FindAsync(orderId);
            if (order == null) return false;

            order.OrderStatus = newStatus; 
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
