using Controllers.Models;

namespace Controllers.Services;

public class FakeOrderService : IOrderService
{
    public List<Order> GetOrders()
    {
        // Fake data - simulates database query
        return
        [
            new Order
            {
                Id = 1,
                ProductName = "Dell XPS 15 Laptop",
                Price = 5499.99m,
                OrderDate = new DateTime(2026, 1, 15)
            },
            new Order
            {
                Id = 2,
                ProductName = "Logitech MX Master Mouse",
                Price = 449.00m,
                OrderDate = new DateTime(2026, 2, 3)
            },
            new Order
            {
                Id = 3,
                ProductName = "Mechanical Keyboard",
                Price = 299.99m,
                OrderDate = new DateTime(2026, 2, 10)
            }
        ];
    }
}