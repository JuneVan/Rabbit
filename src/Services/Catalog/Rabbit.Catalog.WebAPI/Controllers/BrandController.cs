namespace Rabbit.Catalog.WebAPI.Controllers
{
    /// <summary>
    /// 品牌管理
    /// </summary>
    [Route("api/[controller]")] 
    public class BrandController : CatalogControllerBase
    {
        private readonly IBrandQuerier _brandQuerier;
        public BrandController(IServiceProvider serviceProvider, IBrandQuerier brandQuerier)
            : base(serviceProvider)
        {
            _brandQuerier = brandQuerier;
        }

        /// <summary>
        /// 获取一条品牌记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Get/{id}")]
        public async Task<BrandModel> GetByIdAsync(int id)
        {
            return await _brandQuerier.GetBrandByIdAsync(id);
        }
        /// <summary>
        /// 获取品牌记录列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<PagedResultDto<BrandListModel>> GetAllAsync(GetBrandsInput input)
        {
            return await _brandQuerier.GetBrandsAsync(input);
        }
        /// <summary>
        /// 获取品牌下拉项列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetBrandItems")]
        public async Task<List<ComboboxItemDto>> GetBrandItemsAsync()
        {
            return await _brandQuerier.GetBrandItemsAsync();
        }
        /// <summary>
        /// 创建一条品牌记录
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<int> CreateAsync([FromBody] CreateBrandCommand command)
        {
            return await Mediator.Send(command);
        }
        /// <summary>
        /// 更新一条品牌记录
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public async Task UpdateAsync([FromBody] UpdateBrandCommand command)
        {
            await Mediator.Send(command);
        }
        /// <summary>
        /// 删除一条品牌记录
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("Delete")]
        public async Task DeleteAsync([FromBody] UpdateBrandCommand command)
        {
            await Mediator.Send(command);
        }
    }
}
