using eKota.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace eKota.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Category> Categories{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Chicken" },
                new Category { Id = 2, Name = "Beef" },
                new Category { Id = 3, Name = "Vegan" });
        }
    }
}
