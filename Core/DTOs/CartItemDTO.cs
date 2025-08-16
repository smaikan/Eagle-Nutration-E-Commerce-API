namespace Core.DTOs;

public class CartItemDTO
{
    public int CartItemId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public string Aroma { get; set; }
    public string ProductName { get; set; }
    public string ProductImage { get; set; }
    public decimal TotalPrice => UnitPrice * Quantity;


}