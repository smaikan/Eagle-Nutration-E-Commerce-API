using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs.UserDTOs;

namespace Core.DTOs.OrderDTOs
{
   public class OrderDTO
    {
        [Key] 
        public int OrderId { get; set; }
        public int UserId { get; set; } 
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public AddressDTO ShippingAddress { get; set; }

        public string OrderStatus { get; set; } = "Oney Bekliyor";
        public List<OrderDetailDTO> OrderDetails { get; set; }
    }
}
