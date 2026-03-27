using System.ComponentModel.DataAnnotations;

namespace Mini.Modulo.Comercial.API.DTOs
{
    public class CreateOrderItemDto
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser maior que zero")]
        public int Quantity { get; set; }
    }
}
