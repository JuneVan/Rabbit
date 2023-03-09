namespace Rabbit.Catalog.WebAPI.Application.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>,
        IRequestHandler<UpdateCategoryCommand>,
        IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IRepository<Category> _categoryRepository;
        public CreateCategoryCommandHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            var category = new Category(request.Name, request.DisplayOrder);

            if (request.ParentId.HasValue)
            {
                var parent = await _categoryRepository.FirstOrDefaultAsync(request.ParentId.Value);
                category.SetParent(parent);
            } 
            var categoryId = await _categoryRepository.InsertAndGetIdAsync(category);
            await _categoryRepository.UnitOfWork.CommitAsync();
            return categoryId; 
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            // 检查上级分类
            Category parent = null;
            if (request.ParentId.HasValue)
                parent = await _categoryRepository.FirstOrDefaultAsync(request.ParentId.Value);

            var category = await _categoryRepository.FirstOrDefaultAsync(request.Id);
            category.SetName(request.Name);
            category.SetDisplayOrder(request.DisplayOrder);
            category.SetParent(parent);
            await _categoryRepository.UpdateAsync(category);
            await _categoryRepository.UnitOfWork.CommitAsync();
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.FirstOrDefaultAsync(request.Id); 
            await _categoryRepository.DeleteAsync(category);
            await _categoryRepository.UnitOfWork.CommitAsync();
        }
    }
}
