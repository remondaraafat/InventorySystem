using InventoryManagementSystem.Data;

namespace InventoryManagementSystem.Repository
{
    public class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(InventorySystemContext context) : base(context)
        {
        }
    }
}
