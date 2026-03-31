using Microsoft.AspNetCore.Mvc;
using Mini.Modulo.Comercial.API.Data;
using Mini.Modulo.Comercial.API.DTOs;
using Mini.Modulo.Comercial.API.Models;

namespace Mini.Modulo.Comercial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var clients = _context.Clients.ToList();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var client = _context.Clients.SingleOrDefault(x => x.Id == id);
            return Ok(client);
        }

        [HttpPost]
        public IActionResult Post(CreateClientDto dto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var client = new Client
            {
                Name = dto.Name,
                Email = dto.Email
            };

            _context.Clients.Add(client);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = client.Id }, client);
        }
    }
}
