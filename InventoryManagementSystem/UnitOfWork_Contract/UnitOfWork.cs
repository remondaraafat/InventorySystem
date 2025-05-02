using InventoryManagementSystem.Data;

namespace InventoryManagementSystem.UnitOfWork_Contract
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly InventorySystemContext _context;
        readonly IProductRepository _productRepository;
        public UnitOfWork(InventorySystemContext context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }
        public IProductRepository productRepository
        {
            get
            {
                return _productRepository;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
