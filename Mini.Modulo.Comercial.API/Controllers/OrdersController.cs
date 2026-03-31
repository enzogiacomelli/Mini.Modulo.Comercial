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
            try
            {
                order = _orderService.CreateOrder(dto);
                return Ok("Order created! Order id: " + order.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Order> orders = _orderService.GetOrders();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Order order = _orderService.GetOrder(id);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
