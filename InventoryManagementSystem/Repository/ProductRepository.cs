using InventoryManagementSystem.Data;

namespace InventoryManagementSystem.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        InventorySystemContext _context;
        public ProductRepository(InventorySystemContext context) : base(context)
        {
            _context = context;
        }
    }
}
