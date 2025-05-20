using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public decimal Amount { get; set; } 
        public DateTime PaymentDate { get; set; } 
        public string PaymentMethod { get; set; } 
        public string PaymentStatus { get; set; }
       
    }
}
