using InventoryManagementSystem.Data;

namespace InventoryManagementSystem.UnitOfWork_Contract
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly InventorySystemContext _context;
        readonly IProductRepository _productRepository;
        readonly ITransactionHistoryRepository _transactionRepository;
        readonly IProductStockRepository _productStockRepository;


        public UnitOfWork(InventorySystemContext context, IProductRepository productRepository, ITransactionHistoryRepository transactionRepository, IProductStockRepository productStockRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _transactionRepository = transactionRepository;
            _productStockRepository = productStockRepository;
        }
        public IProductRepository productRepository
        {
            get
            {
                return _productRepository;
            }
        }
        public ITransactionHistoryRepository TransactionHistoryRepository
        {
            get
            {
                return _transactionRepository;
            }
        }
        public IProductStockRepository ProductStockRepository
        {
            get
            {
                return _productStockRepository;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
