namespace   Core.Model
{
    public class Product
    {
        public int ProductId { get; set; } 
        public string ProductName { get; set; }
        public int? ProductCategoryId{ get; set; }
        public string? ProductDescription{ get; set; }
        public decimal ProductPrice { get; set; }
        public int Stock { get; set; }

        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
