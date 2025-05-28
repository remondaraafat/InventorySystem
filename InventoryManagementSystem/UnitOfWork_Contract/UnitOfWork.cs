using InventoryManagementSystem.Data;

namespace InventoryManagementSystem.UnitOfWork_Contract
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly InventorySystemContext _context;
         IProductRepository _productRepository;
         ITransactionHistoryRepository _transactionHistoryRepository;
         IProductStockRepository _productStockRepository;
        ICategoryRepository _categoryRepository;
        ITransactionTypeRepository _transactionTypeRepository;
        IWarehouseRepository _warehouseRepository;

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

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_context);
                }
                return _categoryRepository;
            }
        }
        public ITransactionTypeRepository TransactionTypeRepository
        {
            get
            {
                if (_transactionTypeRepository == null)
                {
                    _transactionTypeRepository = new TransactionTypeRepository(_context);
                }
                return _transactionTypeRepository;
            }
        }
        public IWarehouseRepository WarehouseRepository
        {
            get
            {
                if (_warehouseRepository == null)
                {
                    _warehouseRepository = new WarehouseRepository(_context);
                }
                return _warehouseRepository;
            }
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
