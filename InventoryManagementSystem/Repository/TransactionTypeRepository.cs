using InventoryManagementSystem.Data;

namespace InventoryManagementSystem.Repository
{
    public class TransactionTypeRepository : GenericRepository<TransactionType>, ITransactionTypeRepository
    {
        public TransactionTypeRepository(InventorySystemContext context) : base(context)
        {
        }
    }
}
