using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.ProductDTOs
{
    public class ProductCreateDTO
    {
        [Required]
        public string Name { get; set; }

        public string ProductImage { get; set; } 


        [Required]
        [Range(0.01, 100000)]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }

        public List<string>? ProductAroma { get; set; }

        [Required]
        public int ProductCategoryId { get; set; }
    }
}
