using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Salon> Salons { get; set; } = default!;
        public DbSet<Car> Cars { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Salon>();
            modelBuilder.Entity<Car>();
             modelBuilder.Entity<User>();
        }
    }
}
