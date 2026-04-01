using Microsoft.EntityFrameworkCore;
using TextileApp.Data.Entities;

namespace TextileApp.Data
{
    public class TextileDbContext : DbContext
    {
        public TextileDbContext(DbContextOptions<TextileDbContext> options)
            : base(options)
        {
        }

        public DbSet<Material> Materials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
