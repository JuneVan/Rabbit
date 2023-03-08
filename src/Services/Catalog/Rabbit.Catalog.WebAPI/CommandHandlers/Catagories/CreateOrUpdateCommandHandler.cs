using Rabbit.Catalog.AggregateModels.CategoryAggregate;
using Rabbit.Catalog.WebAPI.Commands.Catagories;

namespace Rabbit.Catalog.WebAPI.CommandHandlers.Catagories
{
    public class CreateOrUpdateCommandHandler : IRequestHandler<CreateOrUpdateCommand, int>
    {
        private readonly IRepository<Category> _categoryRepository;
        public CreateOrUpdateCommandHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<int> Handle(CreateOrUpdateCommand request, CancellationToken cancellationToken)
        {
            // 检查上级分类
            Category parent = null;
            if (request.ParentId.HasValue)
                parent = await _categoryRepository.FirstOrDefaultAsync(request.ParentId.Value);
            if (!request.Id.HasValue)
            {
                var category = new Category(request.Name, request.DisplayOrder, parent);
                var categoryId = await _categoryRepository.InsertAndGetIdAsync(category);
                await _categoryRepository.UnitOfWork.CommitAsync();
                return categoryId;
            }
            else
            {
                var category = await _categoryRepository.FirstOrDefaultAsync(request.Id.Value);
                category.SetName(request.Name);
                category.SetDisplayOrder(request.DisplayOrder);
                category.SetParent(parent);
                await _categoryRepository.UpdateAsync(category);
                await _categoryRepository.UnitOfWork.CommitAsync();
                return request.Id.Value;
            }
        }
    }
}
