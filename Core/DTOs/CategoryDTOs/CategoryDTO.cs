using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.CategoryDTOs
{
    public class CategoryDTO
    {
        
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
