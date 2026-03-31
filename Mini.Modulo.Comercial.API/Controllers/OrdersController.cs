using Microsoft.AspNetCore.Mvc;
using Mini.Modulo.Comercial.API.DTOs;
using Mini.Modulo.Comercial.API.Models;
using Mini.Modulo.Comercial.API.Services;

namespace Mini.Modulo.Comercial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpPost]
        public IActionResult Post(CreateOrderDto dto)
        {
            Order order = new Order();
            order = _orderService.CreateOrder(dto);
            return Ok("Order created! Order id: " + order.Id);
        }
    }
}
