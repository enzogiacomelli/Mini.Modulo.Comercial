using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini.Modulo.Comercial.API.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        public Status Status { get; set; }


        [Required]
        public List<OrderItem> Items { get; set; }
    }

    public enum Status
    {
        Pending,
        Completed,
        Cancelled
    }
}
