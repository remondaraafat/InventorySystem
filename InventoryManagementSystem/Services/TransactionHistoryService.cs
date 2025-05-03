using InventoryManagementSystem.DTOs.ProductStockDTOs;
using InventoryManagementSystem.DTOs.TransactionHistoryDTOs;
using InventoryManagementSystem.UnitOfWork_Contract;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services
{
    public class TransactionHistoryService
    {
        IUnitOfWork _unitOfWork;
        public TransactionHistoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
        //add
        public async Task AddTransactionHistoryRequest(AddTransactionHistoryDTO TransactionHistoryDTO)
        {
            TransactionHistory NewTransactionHistory = new TransactionHistory()
            {
                FromWarehouseId = TransactionHistoryDTO.FromWarehouseId,
                ProductId = TransactionHistoryDTO.ProductId,
                Archived = TransactionHistoryDTO.Archived,
                ToWarehouseId = TransactionHistoryDTO.ToWarehouseId,
                TransactionDate = TransactionHistoryDTO.TransactionDate,
                Quantity = TransactionHistoryDTO.Quantity,
                TransactionTypeId = TransactionHistoryDTO.TransactionTypeId,
                UserId = TransactionHistoryDTO.UserId,

            };
            _unitOfWork.TransactionHistoryRepository.AddAsync(NewTransactionHistory);
            //_unitOfWork.Save();
            
        }
        //transaction report
        public async Task<List<GetTransactioHistoryWithFilterDTO>> TransactionReportRequest(int pageNumber, int pageSize, DateTime? date, int? productId)
        {
            var query = _unitOfWork.TransactionHistoryRepository.GetAllAsQueryable()
                .Where(t => !t.Archived);

            if (date.HasValue)
            {
                query = query.Where(t => t.TransactionDate.Date == date);
            }

            if (productId.HasValue)
            {
                query = query.Where(t => t.ProductId == productId);
            }

            return await query
                .OrderByDescending(t => t.TransactionDate)
                .Select(t => new GetTransactioHistoryWithFilterDTO()
                {
                    ID = t.ID,
                    ProductId = t.ProductId,
                    Quantity = t.Quantity,
                    ProductName = t.Product.Name,
                    FromWarehouseName = t.FromWarehouse.Name,
                    Archived = t.Archived,
                    ToWarehouseName = t.ToWarehouse.Name,
                    TransactionDate = t.TransactionDate,
                    FromWarehouseId = t.FromWarehouseId,
                    ToWarehouseId = t.ToWarehouseId,
                    TransactionTypeId = t.TransactionTypeId,
                    UserId = t.UserId,
                    TransactionTypeName = t.TransactionType.Name,
                    UserName = t.User.UserName
                })
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

    }
}
