using Mini.Modulo.Comercial.API.DTOs;
using Mini.Modulo.Comercial.API.Models;

namespace Mini.Modulo.Comercial.API.Services
{
    public interface IOrderService
    {
        Order CreateOrder(CreateOrderDto dto);

        List<Order> GetOrders();
    }
}
