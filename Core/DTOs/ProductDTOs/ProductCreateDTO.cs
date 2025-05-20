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
<<<<<<< HEAD
        public string ProductImage { get; set; } 
=======
>>>>>>> c8e2fb5ef3fe48ae811ce257204a35ad1610721d

        [Required]
        [Range(0.01, 100000)]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
<<<<<<< HEAD
        public List<string>? ProductAroma { get; set; }
=======
>>>>>>> c8e2fb5ef3fe48ae811ce257204a35ad1610721d

        [Required]
        public int ProductCategoryId { get; set; }
    }
}
