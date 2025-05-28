namespace InventoryManagementSystem.UnitOfWork_Contract
{
    public interface IUnitOfWork
    {
        public IProductRepository productRepository { get; }
        public ITransactionHistoryRepository TransactionHistoryRepository { get; }
        public IProductStockRepository ProductStockRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public ITransactionTypeRepository TransactionTypeRepository { get; }
        public IWarehouseRepository WarehouseRepository { get; }



        Task SaveAsync();
    }
}
