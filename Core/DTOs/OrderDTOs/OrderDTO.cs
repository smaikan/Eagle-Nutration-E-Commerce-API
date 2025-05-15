using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.OrderDTOs
{
   public class OrderDTO
    {
        [Key] 
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public string ShippingAddress { get; set; }

        public string OrderStatus { get; set; } = "Oney Bekliyor";

        
        public int UserId { get; set; }
        public string UserFullname { get; set; } 

        public List<OrderDetailDTO> OrderDetails { get; set; }
    }
}
