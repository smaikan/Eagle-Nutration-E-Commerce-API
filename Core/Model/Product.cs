using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace   Core.Model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; } 
<<<<<<< HEAD
        public string ProductImage { get; set; } 
=======
>>>>>>> c8e2fb5ef3fe48ae811ce257204a35ad1610721d
        public string ProductName { get; set; }
        [ForeignKey(nameof(Category.CategoryId))]
        public int? ProductCategoryId{ get; set; }
        public Category Category { get; set; }
        public string? ProductDescription{ get; set; }
<<<<<<< HEAD
        public List<string>? ProductAroma { get; set; }
=======
>>>>>>> c8e2fb5ef3fe48ae811ce257204a35ad1610721d
        public decimal ProductPrice { get; set; }
        public int Stock { get; set; }

       
        public ICollection<Comment> Comments { get; set; }

    }
}
