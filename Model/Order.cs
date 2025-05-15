using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Order
    {   
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime Orderdate { get; set; }
        public Decimal TotarPrice { get; set; }
        public string  ShippingAddress { get; set; }
        public string OrderStatus { get; set; }
    }
}
