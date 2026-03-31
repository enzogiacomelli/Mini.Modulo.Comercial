using Microsoft.AspNetCore.Mvc;
using Mini.Modulo.Comercial.API.Data;
using Mini.Modulo.Comercial.API.Models;
using Mini.Modulo.Comercial.API.DTOs;

namespace Mini.Modulo.Comercial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var products = _context.Products.ToList();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(CreateProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (dto.Price <= 0)
                return BadRequest("Preço deve ser maior que zero");

            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price
            };

            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();

                return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
