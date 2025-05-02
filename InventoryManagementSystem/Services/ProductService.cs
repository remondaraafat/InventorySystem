using InventoryManagementSystem.DTOs.Product;
using InventoryManagementSystem.UnitOfWork_Contract;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services
{
    public class ProductService
    {
        IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        //get
        public async Task<GetProductDTO> GetProductRequest(int id) {
            return await _unitOfWork.productRepository.GetItemAsQueryable(p=>p.ID==id).Select(p => new GetProductDTO
            {
                ID=p.ID,
                ProductName=p.Name,
                ProductDescription=p.Description,
                ProductPrice=p.Price,
                ProductLowStockThreshold=p.LowStockThreshold,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name
            }).FirstOrDefaultAsync();
        }
        public async Task<GetProductDTO> GetProductRequestByName(string name)
        {
            return await _unitOfWork.productRepository.GetItemAsQueryable(p => p.Name == name).Select(p => new GetProductDTO
            {
                ID = p.ID,
                ProductName = p.Name,
                ProductDescription = p.Description,
                ProductPrice = p.Price,
                ProductLowStockThreshold = p.LowStockThreshold,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name
            }).FirstOrDefaultAsync();
        }
        //get all
        public async Task<List<GetAllProductDTO>> GetAllProductRequest()
        {
            return await _unitOfWork.productRepository.GetAllAsQueryable().Select(p => new GetAllProductDTO
            {
                ID = p.ID,
                ProductName = p.Name,
                ProductDescription = p.Description,
                ProductPrice = p.Price,
                ProductLowStockThreshold = p.LowStockThreshold,
                CategoryId=p.CategoryId,
                CategoryName = p.Category.Name
            }).ToListAsync();
        }
        //edit
        public async Task<bool> EditProductRequest(EditProductDTO productDTO) {
            Product productFromDB= await _unitOfWork.productRepository.GetItemAsQueryable(p=>p.ID==productDTO.ID).FirstOrDefaultAsync();

            if (productFromDB == null)
                return false;

            productFromDB.Description = productDTO.ProductDescription;
            productFromDB.Name = productDTO.ProductName;
            productFromDB.Price = productDTO.ProductPrice;
            productFromDB.LowStockThreshold = productDTO.ProductLowStockThreshold;
            productFromDB.CategoryId = productDTO.CategoryId;

            await _unitOfWork.productRepository.UpdateAsync(productFromDB);
            _unitOfWork.Save();
            return true;
        }
        //add
        public async Task<GetProductDTO> AddProductRequest(AddProductDTO productDTO) {
            Product NewProduct = new Product()
            {
                Price = productDTO.ProductPrice,
                Description = productDTO.ProductDescription,
                Name = productDTO.ProductName,
                CategoryId = productDTO.CategoryId,
                LowStockThreshold = productDTO.ProductLowStockThreshold,

            };
            _unitOfWork.productRepository.AddAsync(NewProduct);
            _unitOfWork.Save();
            return await this.GetProductRequestByName(productDTO.ProductName);
        }
        //delete
        public async Task<bool> DeleteRequest(int id ) {
            bool result =await _unitOfWork.productRepository.Delete(p => p.ID == id);
            _unitOfWork.Save();
            return result;
        }
    }
}
