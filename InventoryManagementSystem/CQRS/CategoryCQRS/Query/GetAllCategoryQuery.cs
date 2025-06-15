using InventoryManagementSystem.DTOs.CategoryDTOs;
using InventoryManagementSystem.UnitOfWork_Contract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.CQRS.CategoryCQRS.Query
{
    public class GetAllCategoryQuery : IRequest<List<GetAllCategoryDTO>>
    {

    }
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<GetAllCategoryDTO>>
    {
        IUnitOfWork _unitOfWork;
        public GetAllCategoryQueryHandler(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }
        public async Task<List<GetAllCategoryDTO>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CategoryRepository.GetAllAsQueryable().Select(p => new GetAllCategoryDTO
            {
                ID = p.ID,
                Name = p.Name,

            }).ToListAsync();
        }
    }
}
/// IRequest => MediatR see every query or command as IRequest
/// we use IRequest for generalization only 
/// IRequest => تمثل الاوبجكت اللى بيحمل مجموعه البيانات اللى لازمه لتنفيذ هذا الريكويست
/// mediateR => بيقدر يفرق بين الريكويست والريكويست هاندلر 
///  Request handler => responsible for handl the request
///  data will be passed to => IRequest
///  action code will be written inside => Irequest handler
///  generic IREquestHandler <the Request the handler resposible for excution , return type>
///  generic IRequest<return type>
///  IREquestHandler =>has handle function that take IRequest and return the model(DTO,VM)
///  
