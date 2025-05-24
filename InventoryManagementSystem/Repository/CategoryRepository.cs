using InventoryManagementSystem.Data;

namespace InventoryManagementSystem.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(InventorySystemContext context) : base(context)
        {
        }
    }
}
