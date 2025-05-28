using InventoryManagementSystem.DTOs.TransactionTypeDTOs;
using InventoryManagementSystem.DTOs.WarehouseDTOs;
using InventoryManagementSystem.UnitOfWork_Contract;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services
{
    public class WarehouseService
    {
        IUnitOfWork _unitOfWork;
        public WarehouseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //get all
        public async Task<List<GetAllWarehouseDTO>> GetAllWarehouseRequest()
        {
            return await _unitOfWork.WarehouseRepository.GetAllAsQueryable().Select(w => new GetAllWarehouseDTO
            {
                ID = w.ID,
                Name = w.Name,
                Location = w.Location,
            }).ToListAsync();
        }
    }
}
