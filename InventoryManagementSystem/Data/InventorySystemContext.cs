using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace InventoryManagementSystem.Data
{
    public class InventorySystemContext : IdentityDbContext
    {
        public InventorySystemContext(DbContextOptions<InventorySystemContext> options):base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        
    }
}
