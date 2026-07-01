using Microsoft.EntityFrameworkCore;
using mini_store.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace mini_store.Data
{
   
    public class AppDbContext : IdentityDbContext<AppUser>
    {
         //initlize context
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Add DbSet<TEntity> properties for your entities here.
        // Example:
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}
