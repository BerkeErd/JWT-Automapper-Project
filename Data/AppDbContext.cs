using JWT_Automapper_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace JWT_Automapper_Project.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
