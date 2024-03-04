using Microsoft.EntityFrameworkCore;
using WebApi.Entity;
using WebApi.Interface;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApi.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Produto> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>().ToTable("Produto");
        }
    }
}
