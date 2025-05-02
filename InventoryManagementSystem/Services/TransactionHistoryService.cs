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
            _unitOfWork.Save();
            
        }
    }
}
