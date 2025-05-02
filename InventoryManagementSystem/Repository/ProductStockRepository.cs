using InventoryManagementSystem.Data;

namespace InventoryManagementSystem.Repository
{
    public class ProductStockRepository : GenericRepository<ProductStock>, IProductStockRepository
    {
        public ProductStockRepository(InventorySystemContext context) : base(context)
        {
        }
    }
}
