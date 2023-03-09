using Rabbit.Catalog.WebAPI.Application.Queries;

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
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getcategories")]
        public async Task<PagedResultDto<CategoryListModel>> GetCategoriesAsync([FromQuery] GetCategoriesInput input)
        {
            return await _categoryQuerier.GetCategoriesAsync(input);
        }

        /// <summary>
        /// 获取一条分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get/{id}")]
        public async Task<CategoryModel> GetByIdAsync(int id)
        {
            return await _categoryQuerier.GetCategoryByIdAsync(id);
        }

        /// <summary>
        /// 创建分类
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task CreateAsync([FromBody] CreateCategoryCommand command)
        {
            await Mediator.Send(command);
        }

        /// <summary>
        /// 更新分类
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task UpdateAsync([FromBody] UpdateCategoryCommand command)
        {
            await Mediator.Send(command);
        }
    }
}
