using InventoryManagementSystem.DTOs.CategoryDTOs;
using MediatR;

namespace InventoryManagementSystem.CQRS.Orchestrators
{
    public class AddCategoryOrchestrator:IRequest<GetAllCategoryDTO>
    {
        public string Name { get; set; }
    }
    public class AddCategoryOrchestratorHandler : IRequestHandler<AddCategoryOrchestrator, GetAllCategoryDTO>
    {
        public Task<GetAllCategoryDTO> Handle(AddCategoryOrchestrator request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
