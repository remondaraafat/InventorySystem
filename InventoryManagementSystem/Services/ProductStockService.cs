using InventoryManagementSystem.DTOs.ProductStockDTOs;
using InventoryManagementSystem.DTOs.TransactionHistoryDTOs;
using InventoryManagementSystem.UnitOfWork_Contract;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services
{
    public class ProductStockService
    {
        IUnitOfWork _unitOfWork;
        TransactionHistoryService _transactionHistoryService;
        public ProductStockService(IUnitOfWork unitOfWork,TransactionHistoryService transactionHistoryService)
        {
            _unitOfWork = unitOfWork;
            _transactionHistoryService = transactionHistoryService;
        }
    
        //increase
        public async Task<bool> IncreaseStockAndLogTransactionRequest(IncreaseProductStockDTO DTO,string userId)
        {
            ProductStock productStockFromDB = await _unitOfWork.ProductStockRepository.GetItemAsQueryable(p => p.ID == DTO.ID).FirstOrDefaultAsync();
            if (productStockFromDB == null) return false;
            Product productFromDB=await _unitOfWork.productRepository.GetItemAsQueryable(p => p.ID == productStockFromDB.ProductId).FirstOrDefaultAsync();
            if (productFromDB == null) return false;

            //quantity
            
            int newQuantity = productStockFromDB.Quantity + Math.Abs(DTO.QuantityChange); ;
            if (newQuantity < 0) return false;
            productStockFromDB.Quantity = newQuantity;


            //other prop
            AddTransactionHistoryDTO transactionHistory = new AddTransactionHistoryDTO()
            {
                Quantity = Math.Abs(DTO.QuantityChange),
                FromWarehouseId = productStockFromDB.WarehouseId,
                ProductId = productFromDB.ID,
                TransactionTypeId = DTO.TransactionTypeId,
                UserId = userId
            };
            
            if (productStockFromDB.Quantity<productFromDB.LowStockThreshold)
            {
            //TODO: real time notification or mail
            }
            await _transactionHistoryService.AddTransactionHistoryRequest(transactionHistory);
            await _unitOfWork.ProductStockRepository.UpdateAsync(productStockFromDB);

            await _unitOfWork.SaveAsync();
            return true;
        }
        //decrease
        public async Task<bool> DecreaseStockAndLogTransactionRequest(DecreaseProductStockDTO DTO, string userId)
        {
            ProductStock productStockFromDB = await _unitOfWork.ProductStockRepository.GetItemAsQueryable(p => p.ID == DTO.ID).FirstOrDefaultAsync();
            if (productStockFromDB == null) return false;
            Product productFromDB = await _unitOfWork.productRepository.GetItemAsQueryable(p => p.ID == productStockFromDB.ProductId).FirstOrDefaultAsync();
            if (productFromDB == null) return false;

            //quantity

            int newQuantity = productStockFromDB.Quantity - Math.Abs(DTO.QuantityChange) ;
            if (newQuantity < 0) return false;
            productStockFromDB.Quantity = newQuantity;

            //other prop
            AddTransactionHistoryDTO transactionHistory = new AddTransactionHistoryDTO()
            {
                Quantity = Math.Abs(DTO.QuantityChange),
                FromWarehouseId = productStockFromDB.WarehouseId,
                ProductId = productFromDB.ID,
                TransactionTypeId = DTO.TransactionTypeId,
                UserId = userId
            };

            if (productStockFromDB.Quantity < productFromDB.LowStockThreshold)
            {
                //TODO: real time notification or mail
            }
            await _transactionHistoryService.AddTransactionHistoryRequest(transactionHistory);
            await _unitOfWork.ProductStockRepository.UpdateAsync(productStockFromDB);

            await _unitOfWork.SaveAsync();
            return true;
        }
        //transfer
        public async Task<bool> TransferStockAndLogTransactionRequest(TransferProductStockDTO DTO, string userId)
        {
            ProductStock sourceStockFromDb = await _unitOfWork.ProductStockRepository.GetItemAsQueryable(p => p.ID == DTO.ID).FirstOrDefaultAsync();
            ProductStock DestinationStockFromDB = await _unitOfWork.ProductStockRepository.GetItemAsQueryable(p => p.ID == DTO.DestinatioStockId).FirstOrDefaultAsync();
            Product productFromDB = await _unitOfWork.productRepository.GetItemAsQueryable(p => p.ID == sourceStockFromDb.ProductId).FirstOrDefaultAsync();

            int AbsQuantityChange = Math.Abs(DTO.QuantityChange);
                if (DestinationStockFromDB == null || sourceStockFromDb == null|| productFromDB == null|| sourceStockFromDb.Quantity< DTO.QuantityChange) return false;
            AddTransactionHistoryDTO transactionHistory = new AddTransactionHistoryDTO()
            {
                Quantity = AbsQuantityChange,
                FromWarehouseId = sourceStockFromDb.WarehouseId,
                ProductId = productFromDB.ID,
                TransactionTypeId = DTO.TransactionTypeId,
                UserId = userId
            };

            DestinationStockFromDB.Quantity += AbsQuantityChange;
            sourceStockFromDb.Quantity -= AbsQuantityChange;
            transactionHistory.ToWarehouseId = DTO.DestinationWarehouseId;

            if (sourceStockFromDb.Quantity < productFromDB.LowStockThreshold)
            {
                //real time notification or mail
            }
            await _transactionHistoryService.AddTransactionHistoryRequest(transactionHistory);
            await _unitOfWork.ProductStockRepository.UpdateAsync(sourceStockFromDb);
            await _unitOfWork.ProductStockRepository.UpdateAsync(DestinationStockFromDB);
            await _unitOfWork.SaveAsync();
            return true;
        }
        //low stock report
        public async Task<List<LowStockDTO>> LowStockRequest(int pageNumber, int pageSize) {
            return await _unitOfWork.ProductStockRepository.GetAllAsQueryable().Select(s => new LowStockDTO() { 
            ID = s.ID,
            ProductId= s.ProductId,
            WarehouseId = s.WarehouseId,
            Quantity = s.Quantity,
            LowStockThreshold=s.Product.LowStockThreshold,
            ProductName=s.Product.Name,
            WarehouseName=s.Warehouse.Name
            }).Where(dto=>dto.Quantity<dto.LowStockThreshold)
            .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();


        }
        //low stock report
        public async Task<List<GetAllStockWithFilterDTO>> GetAllStockwithFilterRequest(
    int pageNumber, int pageSize, int? ProductID, int? WarehouseID)
        {
            var query = _unitOfWork.ProductStockRepository.GetAllAsQueryable()
                .Select(s => new GetAllStockWithFilterDTO
                {
                    ID = s.ID,
                    ProductId = s.ProductId,
                    WarehouseId = s.WarehouseId,
                    Quantity = s.Quantity,
                    LowStockThreshold = s.Product.LowStockThreshold,
                    ProductName = s.Product.Name,
                    WarehouseName = s.Warehouse.Name 
                });

            if (ProductID>0)
                query = query.Where(dto => dto.ProductId == ProductID.Value);

            if (WarehouseID>0)
                query = query.Where(dto => dto.WarehouseId == WarehouseID.Value);

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

    }
}
