using System.ComponentModel.DataAnnotations;

namespace Mini.Modulo.Comercial.API.DTOs
{
    public class CreateClientDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
