using Microsoft.EntityFrameworkCore;
using Mini.Modulo.Comercial.API.Models;

namespace Mini.Modulo.Comercial.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
