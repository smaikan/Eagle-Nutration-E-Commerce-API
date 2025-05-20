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
<<<<<<< HEAD
        public string ProductImage { get; set; } 
=======
>>>>>>> c8e2fb5ef3fe48ae811ce257204a35ad1610721d
        [Required]
        public string ProductName { get; set; }
        [Range(0.01, 100000)]
        public decimal ProductPrice { get; set; }
        public int Stock { get; set; }
        public string? ProductDescription { get; set; }
<<<<<<< HEAD
        public List<string>? ProductAroma { get; set; }
=======
>>>>>>> c8e2fb5ef3fe48ae811ce257204a35ad1610721d
        public int ProductCategoryId { get; set; }
    }
}
