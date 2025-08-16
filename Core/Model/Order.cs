using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Core.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Required]
        public Decimal? TotalPrice { get; set; }
        [Required]
        public ShippingAddress ShippingAddress { get; set; }
        public string OrderStatus { get; set; } = "Sipariş Verildi.";
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }

    [Owned]
    public class ShippingAddress
    {
        public string Province { get; set; }
        public string District { get; set; }
        public string Neighbor { get; set; }
        public string Address { get; set; }
    }
}
