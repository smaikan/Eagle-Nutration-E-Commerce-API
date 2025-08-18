using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace   Core.Model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; } 

        public string ProductImage { get; set; } 

        public string ProductName { get; set; }
        [ForeignKey(nameof(Category.CategoryId))]
        public int? ProductCategoryId{ get; set; }
        public Category Category { get; set; }
        public string? ProductDescription{ get; set; }

        public List<string>? ProductAroma { get; set; }

        public decimal ProductPrice { get; set; }
        public int Stock { get; set; }

       
        public ICollection<Comment>? Comments { get; set; }

    }
}
