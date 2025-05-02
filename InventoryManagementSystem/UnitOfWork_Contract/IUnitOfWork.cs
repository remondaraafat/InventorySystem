namespace InventoryManagementSystem.UnitOfWork_Contract
{
    public interface IUnitOfWork
    {
        public IProductRepository productRepository { get; }
        void Save();
    }
}
