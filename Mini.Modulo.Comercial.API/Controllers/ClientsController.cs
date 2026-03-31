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
            try
            {
                var clients = _context.Clients.ToList();
                return Ok(clients);
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
                var client = _context.Clients.SingleOrDefault(x => x.Id == id);
                return Ok(client);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
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

            try
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
                return CreatedAtAction(nameof(Get), new { id = client.Id }, client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
