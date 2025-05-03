namespace InventoryManagementSystem.UnitOfWork_Contract
{
    public interface IUnitOfWork
    {
        public IProductRepository productRepository { get; }
        public ITransactionHistoryRepository TransactionHistoryRepository { get; }
        public IProductStockRepository ProductStockRepository { get; }


        Task SaveAsync();
    }
}
