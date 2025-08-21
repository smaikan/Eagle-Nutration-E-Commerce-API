using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Core.Model
{
    [Owned]
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        [Required]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImage { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string? Aroma { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
