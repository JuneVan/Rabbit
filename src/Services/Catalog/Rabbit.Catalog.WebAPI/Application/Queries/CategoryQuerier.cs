namespace Rabbit.Catalog.WebAPI.Application.Queries
{

    public class CategoryQuerier : ICategoryQuerier
    {
        private readonly IMapper _mapper;
        private readonly IThreadSignal _signal;
        private readonly IRepository<Category> _categoryRepository;
        public CategoryQuerier(IRepository<Category> categoryRepository,
            IMapper mapper,
            IThreadSignal signal)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _signal = signal;
        }

        public async Task<CategoryModel> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.FirstOrDefaultAsync(id);
            return _mapper.Map<CategoryModel>(category);
        }

        public async Task<PagedResultDto<CategoryListModel>> GetCategoriesAsync(GetCategoriesInput input)
        {
            var query = _categoryRepository.GetAll();


            var totalCount = await query.CountAsync(_signal.CancellationToken);
            var categories = await query.OrderBy(input.Sorting)
                    .Skip((input.PageIndex - 1) * input.PageSize)
                    .Take(input.PageSize)
                   .ToListAsync(_signal.CancellationToken);

            return new PagedResultDto<CategoryListModel>(totalCount, _mapper.Map<List<CategoryListModel>>(categories));
        }

        public async Task<List<TreeItemDto>> GetCategoryTreeItemsAsync()
        {
            var categories = await _categoryRepository.GetAllListAsync();
            return RecursivelyCategory(categories, null);
        }
        private List<TreeItemDto> RecursivelyCategory(List<Category> categories, int? parentId)
        {
            var childCategories = categories.Where(x => x.ParentId == parentId);
            if (!childCategories.IsNullOrEmpty())
            {
                var childItems = new List<TreeItemDto>();
                foreach (var category in childCategories)
                {
                    var childItem = new TreeItemDto(category.Id, category.Name);
                    childItem.Children = RecursivelyCategory(categories, category.Id);
                    childItems.Add(childItem);
                }
                return childItems;
            }
            return null;
        }
    }
}
