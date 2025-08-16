using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Cart
    {
        public int CartId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public ICollection<CartItem> CartItems { get; set; } = [];
        public decimal TotalPrice { get; set; } 
    }
}
