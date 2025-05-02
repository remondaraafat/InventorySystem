using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace InventoryManagementSystem.Data
{
    public class InventorySystemContext : IdentityDbContext<ApplicationUser>
    {
        public InventorySystemContext(DbContextOptions<InventorySystemContext> options):base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<Warehouse>()
                .HasIndex(w => w.Name)
                .IsUnique();

            modelBuilder.Entity<TransactionType>()
                .HasIndex(t => t.Name)
                .IsUnique();  
        }

    }
}
