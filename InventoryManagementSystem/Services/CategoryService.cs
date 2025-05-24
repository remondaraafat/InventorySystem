using InventoryManagementSystem.DTOs.CategoryDTOs;
using InventoryManagementSystem.UnitOfWork_Contract;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services
{
    public class CategoryService
    {
        IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //get all
        public async Task<List<GetAllCategoryDTO>> GetAllCategoryRequest()
        {
            return await _unitOfWork.CategoryRepository.GetAllAsQueryable().Select(p => new GetAllCategoryDTO
            {
                ID = p.ID,
                Name = p.Name,
                
            }).ToListAsync();
        }
        
        //add
        public async Task AddCategoryRequest(CreateCateoryDTO DTO)
        {
            Category NewCategory = new Category()
            {
                Name = DTO.Name

            };
            _unitOfWork.CategoryRepository.AddAsync(NewCategory);
            await _unitOfWork.SaveAsync();
            
        }
    }
}
