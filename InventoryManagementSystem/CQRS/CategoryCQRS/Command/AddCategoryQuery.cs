using InventoryManagementSystem.UnitOfWork_Contract;
using MediatR;

namespace InventoryManagementSystem.CQRS.CategoryCQRS.Command
{
    public class AddCategoryQuery : IRequest
    {
        public string Name {get; set;}
    }
    public class AddCategoryQueryHandler : IRequestHandler<AddCategoryQuery>
    {
        IUnitOfWork _unitOfWork;
        public AddCategoryQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(AddCategoryQuery request, CancellationToken cancellationToken)
        {
            await _unitOfWork.CategoryRepository.AddAsync(new Category {Name=request.Name });
            await _unitOfWork.SaveAsync();
        }
    }
}
/// command => is action change state of a model(add, update, delete)
/// (command - query) should be responsible for 1( command - query)
/// i can't inject more than one repository in one request
/// command can't excute command
/// command can excute query
/// validation should hapen in the handeler
/// i can inject the mediator and call request inside anothe request
/// Orchestrators => is a request determin flow of business(flow of command excution)
/// 
