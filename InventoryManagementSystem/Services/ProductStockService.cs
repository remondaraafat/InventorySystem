using InventoryManagementSystem.DTOs.ProductStockDTOs;
using InventoryManagementSystem.DTOs.TransactionHistoryDTOs;
using InventoryManagementSystem.UnitOfWork_Contract;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services
{
    public class ProductStockService
    {
        IUnitOfWork _unitOfWork;
        public ProductStockService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    
        //edit
        public async Task<bool> IncreaseOrDecreaseStockRequest(EditQuantityProductStockDTO editQuantityProductStockDTO)
        {
            ProductStock productStockFromDB = await _unitOfWork.ProductStockRepository.GetItemAsQueryable(p => p.ID == editQuantityProductStockDTO.ID).FirstOrDefaultAsync();
            Product productFromDB=await _unitOfWork.productRepository.GetItemAsQueryable(p => p.ID == productStockFromDB.ProductId).FirstOrDefaultAsync();

            if (productStockFromDB == null)
                return false;
            TransactionHistory transactionHistory = new TransactionHistory();
            transactionHistory.FromWarehouseId = productStockFromDB.ID;

            if (editQuantityProductStockDTO.NewWarehouseId !=null)
            {
                transactionHistory.ToWarehouseId= productStockFromDB.WarehouseId = editQuantityProductStockDTO.NewWarehouseId;
            }
            productStockFromDB.Quantity=editQuantityProductStockDTO.NewQuantity;
            //notification
            if (productStockFromDB.Quantity<productFromDB.LowStockThreshold)
            {

            }
            //identity

            await _unitOfWork.ProductStockRepository.UpdateAsync(productStockFromDB);
            _unitOfWork.Save();
            return true;
        }
    }
}
