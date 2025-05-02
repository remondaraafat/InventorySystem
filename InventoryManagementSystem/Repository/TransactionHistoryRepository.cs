using InventoryManagementSystem.Data;

namespace InventoryManagementSystem.Repository
{
    public class TransactionHistoryRepository : GenericRepository<TransactionHistory>, ITransactionHistoryRepository
    {
        public TransactionHistoryRepository(InventorySystemContext context) : base(context)
        {
        }
    }
}
