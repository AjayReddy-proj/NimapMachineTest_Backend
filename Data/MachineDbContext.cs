using MachineTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace MachineTest.Data
{
    public class MachineDbContext : DbContext
    {
        public MachineDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
