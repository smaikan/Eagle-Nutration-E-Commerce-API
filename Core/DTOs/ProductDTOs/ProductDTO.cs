using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs.CategoryDTOs;

namespace Core.DTOs.ProductDTOs
{
    public class ProductDTO
    {
        [Key]
        public int ProductId { get; set; }
<<<<<<< HEAD
        public string ProductImage { get; set; } 
=======
>>>>>>> c8e2fb5ef3fe48ae811ce257204a35ad1610721d
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
<<<<<<< HEAD
        public List<string>? ProductAroma { get; set; }
=======
>>>>>>> c8e2fb5ef3fe48ae811ce257204a35ad1610721d
        public int ProductCategoryId { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
