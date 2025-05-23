using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Order
    {   
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Required]
        public Decimal TotalPrice { get; set; }
        [Required]
        public string  ShippingAddress { get; set; }
        public string OrderStatus { get; set; } = "Onay Bekleniyor";
        public User User { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
