namespace Model
{
    public class Product
    {
        public int ProductId { get; set; } 
        public string? ProductName { get; set; }
        public string? ProductCategoryId{ get; set; }
        public string? ProductDescription{ get; set; }
        public string? ProductComments{ get; set; }
        public decimal ProductPrice { get; set; }
        public string? ProductAroma { get; set; }
        public int Stock { get; set; }
       
    }
}
