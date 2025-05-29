using InventoryManagementSystem.DTOs.CategoryDTOs;
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
        //add
        public async Task AddًWarehouseRequest(CreateWarehouseDTO DTO)
        {
            Warehouse newWarehouse = new Warehouse()
            {
                Name = DTO.Name,
                Location = DTO.Location

            };
            _unitOfWork.WarehouseRepository.AddAsync(newWarehouse);
            await _unitOfWork.SaveAsync();

        }
    }
}
