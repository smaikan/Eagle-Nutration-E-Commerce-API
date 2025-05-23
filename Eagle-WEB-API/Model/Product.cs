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
<<<<<<< HEAD
        public string? ProductAroma { get; set; }
=======
>>>>>>> c8e2fb5ef3fe48ae811ce257204a35ad1610721d
        public int Stock { get; set; }
       
    }
}
