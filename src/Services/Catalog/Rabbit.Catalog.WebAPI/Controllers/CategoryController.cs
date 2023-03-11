namespace Rabbit.Catalog.WebAPI.Controllers
{
    [Route("v1/[controller]")]
    public class CategoryController : CatalogControllerBase
    {
        private readonly ICategoryQuerier _categoryQuerier;
        public CategoryController(IServiceProvider serviceProvider,
            ICategoryQuerier categoryQuerier)
            : base(serviceProvider)
        {
            _categoryQuerier = categoryQuerier;
        }

        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("GetCategories")]
        public async Task<PagedResultDto<CategoryListModel>> GetCategoriesAsync([FromQuery] GetCategoriesInput input)
        {
            return await _categoryQuerier.GetCategoriesAsync(input);
        }

        /// <summary>
        /// 获取一条分类记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Get/{id}")]
        public async Task<CategoryModel> GetByIdAsync(int id)
        {
            return await _categoryQuerier.GetCategoryByIdAsync(id);
        }
        /// <summary>
        /// 获取分类树列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTreeItems")]
        public async Task<List<TreeItemDto>> GetTreeItemsAsync( )
        {
            return await _categoryQuerier.GetCategoryTreeItemsAsync();
        }

        /// <summary>
        /// 创建一条分类记录
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<int> CreateAsync([FromBody] CreateCategoryCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// 更新一条分类记录
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public async Task UpdateAsync([FromBody] UpdateCategoryCommand command)
        {
            await Mediator.Send(command);
        }

        /// <summary>
        /// 删除一条分类记录
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("Delete")]
        public async Task DeleteAsync([FromBody] DeleteCategoryCommand command)
        {
            await Mediator.Send(command);
        }
    }
}
