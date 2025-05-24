using InventoryManagementSystem.DTOs.CategoryDTOs;
using InventoryManagementSystem.DTOs.TransactionTypeDTOs;
using InventoryManagementSystem.UnitOfWork_Contract;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services
{
    public class TransactionTypeService
    {
        IUnitOfWork _unitOfWork;
        public TransactionTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //get all
        public async Task<List<GetAllTransactionTypeDTO>> GetAllTransactionTypeRequest()
        {
            return await _unitOfWork.TransactionTypeRepository.GetAllAsQueryable().Select(p => new GetAllTransactionTypeDTO
            {
                ID = p.ID,
                Name = p.Name,

            }).ToListAsync();
        }

        //add
        public async Task AddTransactionTypeRequest(CreateTransactionTypeDTO DTO)
        {
            TransactionType NewTransactionType = new TransactionType()
            {
                Name = DTO.Name

            };
            _unitOfWork.TransactionTypeRepository.AddAsync(NewTransactionType);
            await _unitOfWork.SaveAsync();

        }
    }
}
