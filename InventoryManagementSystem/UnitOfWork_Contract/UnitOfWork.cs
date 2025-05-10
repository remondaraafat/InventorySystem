using InventoryManagementSystem.Data;

namespace InventoryManagementSystem.UnitOfWork_Contract
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly InventorySystemContext _context;
         IProductRepository _productRepository;
         ITransactionHistoryRepository _transactionHistoryRepository;
         IProductStockRepository _productStockRepository;


        public UnitOfWork(InventorySystemContext context)
        {
            _context = context;


        }
        public IProductRepository productRepository
        {
            get
            {
                if (_productRepository==null){
                _productRepository = new ProductRepository(_context);
                }
            
                return _productRepository;
            }
        }
        public ITransactionHistoryRepository TransactionHistoryRepository
        {
            get
            {
                if (_transactionHistoryRepository == null)
                {
                    _transactionHistoryRepository = new TransactionHistoryRepository(_context);
                }
                return _transactionHistoryRepository;
            }
        }
        public IProductStockRepository ProductStockRepository
        {
            get
            {
                if (_productStockRepository == null)
                {
                    _productStockRepository = new ProductStockRepository(_context);
                }
                return _productStockRepository;
            }
        }
        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
