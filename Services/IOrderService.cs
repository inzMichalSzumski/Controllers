using Controllers.Models;

namespace Controllers.Services;

public interface IOrderService
{
    List<Order> GetOrders();
}