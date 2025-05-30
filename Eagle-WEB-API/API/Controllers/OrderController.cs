﻿using Core.DTOs.OrderDTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody] OrderCreateDTO orderCreateDto)
        {
            if (orderCreateDto == null)
            {
                return BadRequest("Sipariş verileri geçersiz.");
            }

            var orderDto = await _orderService.CreateOrderAsync(orderCreateDto);

            return CreatedAtAction(nameof(GetOrderByIdAsync), new { id = orderDto.OrderId }, orderDto);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByIdAsync(int id)
        {
            var orderDto = await _orderService.GetOrderByIdAsync(id);
            if (orderDto == null)
            {
                return NotFound("Sipariş bulunamadı.");
            }

            return Ok(orderDto);
        }

        // Kullanıcı ID'sine göre siparişleri al
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetOrdersByUserIdAsync(int userId)
        {
            var orderDtos = await _orderService.GetOrdersByUserIdAsync(userId);
            if (orderDtos == null || orderDtos.Count == 0)
            {
                return NotFound("Kullanıcıya ait sipariş bulunamadı.");
            }

            return Ok(orderDtos);
        }

        // Tüm siparişleri al
        [HttpGet]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var orderDtos = await _orderService.GetAllOrdersAsync();
            return Ok(orderDtos);
        }

        // Siparişi sil
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            var result = await _orderService.DeleteOrderAsync(id);
            if (!result)
            {
                return NotFound("Sipariş bulunamadı.");
            }

            return NoContent(); // Sipariş silindiğinde boş yanıt döneriz
        }

        // Sipariş durumunu güncelle
        [HttpPut("{orderId}")]
        public async Task<IActionResult> UpdateOrderStatusAsync(int orderId, [FromBody] string newStatus)
        {
            var result = await _orderService.UpdateOrderStatusAsync(orderId, newStatus);
            if (!result)
            {
                return NotFound("Sipariş bulunamadı.");
            }

            return Ok("Sipariş durumu başarıyla güncellendi.");
        }
    }
}
