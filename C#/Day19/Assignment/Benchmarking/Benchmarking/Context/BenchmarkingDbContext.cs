using Benchmarking.Entities;
using Microsoft.EntityFrameworkCore;

namespace Benchmarking.Context
{
    public class BenchmarkingDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BenchDb;Trusted_Connection=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.Property(x => x.FirstName).HasMaxLength(100);
                e.Property(x => x.LastName).HasMaxLength(100);
                e.Property(x => x.Email).HasMaxLength(255);
                e.HasIndex(x => x.Email).IsUnique();
            });
        }
    }
}
