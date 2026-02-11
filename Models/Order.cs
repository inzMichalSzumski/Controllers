namespace Controllers.Models;

public class Order
{
    public int Id { get; set; }
    public required string ProductName { get; set; }
    public decimal Price { get; set; }
    public DateTime OrderDate { get; set; }
}