using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.ProductDTOs
{
    public class ProductUpdateDTO
    {
        [Required]
        public int ProductId { get; set; }

        public string ProductImage { get; set; } 

        [Required]
        public string ProductName { get; set; }
        [Range(0.01, 100000)]
        public decimal ProductPrice { get; set; }
        public int Stock { get; set; }
        public string? ProductDescription { get; set; }

        public List<string>? ProductAroma { get; set; }

        public int ProductCategoryId { get; set; }
    }
}
