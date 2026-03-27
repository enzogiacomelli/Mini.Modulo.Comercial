using System.ComponentModel.DataAnnotations;

namespace Mini.Modulo.Comercial.API.DTOs
{
    public class CreateOrderDto
    {
        [Required]
        public int ClientId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "O pedido deve ter pelo menos um item")]
        public List <CreateOrderItemDto> Items { get; set; }
    }
}
