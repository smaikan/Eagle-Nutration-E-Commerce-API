using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Model
{
    public class CartItem
    {
        public int CartItemId { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int ProductId { get; set; }
        public Product Products { get; set; }
        public string aroma { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        
    }

}