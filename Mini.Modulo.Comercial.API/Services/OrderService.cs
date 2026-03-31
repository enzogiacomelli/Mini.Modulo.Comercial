using Mini.Modulo.Comercial.API.Data;
using Mini.Modulo.Comercial.API.DTOs;
using Mini.Modulo.Comercial.API.Models;

namespace Mini.Modulo.Comercial.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public Order CreateOrder(CreateOrderDto dto)
        {
            var order = new Order()
            {
                ClientId = dto.ClientId,
                TotalAmount = 0,
                Status = Status.Pending,
                Items = dto.Items.Select(i => new OrderItem()
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = 0
                }).ToList()
            };

            if (ValidateClient(order))
            {
                if (ValidateItemList(order))
                {
                    for (int i = 0; i < order.Items.Count; i++)
                    {
                        var product = _context.Products.SingleOrDefault(p => p.Id == order.Items[i].ProductId);
                        if (product != null)
                        {
                            order.Items[i].ProductId = product.Id;
                            order.Items[i].Quantity = order.Items[i].Quantity;
                            order.Items[i].UnitPrice = product.Price;
                            order.TotalAmount += product.Price * order.Items[i].Quantity;
                        }
                        else
                        {
                            throw new Exception($"Produto com id {order.Items[i].ProductId} não encontrado");
                        }
                    }
                    _context.Orders.Add(order);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Lista de itens inválida");
                }
            }
            else
            {
                throw new Exception("Cliente não encontrado");
            }
            return order;
        }
    

    bool ValidateClient(Order order)
        {
            var selectClient = _context.Clients.SingleOrDefault(c => c.Id == order.ClientId);
            if (selectClient.Id == order.ClientId)
                return true;
            return false;
        }

    bool ValidateItemList(Order order)
        {
            if (order.Items.Count > 0)
                return true;
            return false;
        }
    }
}
