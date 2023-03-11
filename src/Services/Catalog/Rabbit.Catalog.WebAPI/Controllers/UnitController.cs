namespace Rabbit.Catalog.WebAPI.Controllers
{
    /// <summary>
    /// 计量单位管理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : CatalogControllerBase
    {
        private readonly IUnitQuerier _unitQuerier;
        public UnitController(IServiceProvider serviceProvider,
            IUnitQuerier unitQuerier)
            : base(serviceProvider)
        {
            _unitQuerier = unitQuerier;
        }
        /// <summary>
        /// 获取一条计量单位记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Get/{id}")]
        public async Task<UnitModel> GetByIdAsync(int id)
        {
            return await _unitQuerier.GetUnitByIdAsync(id);
        }
        /// <summary>
        /// 获取计量单位记录列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("GetUnits")]
        public async Task<PagedResultDto<UnitListModel>> GetUnitsAsync(GetUnitsInput input)
        {
            return await _unitQuerier.GetUnitsAsync(input);
        }
        /// <summary>
        /// 获取计量单位下拉项列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUnitItems")]
        public async Task<List<ComboboxItemDto>> GetUnitItemsAsync()
        {
            return await _unitQuerier.GetUnitItemsAsync();
        }
        /// <summary>
        /// 创建一条计量单位记录
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<int> CreateAsync([FromBody] CreateUnitCommand command)
        {
            return await Mediator.Send(command);
        }
        /// <summary>
        /// 更新一条计量单位记录
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public async Task UpdateAsync([FromBody] UpdateUnitCommand command)
        {
            await Mediator.Send(command);
        }
        /// <summary>
        /// 删除一条计量单位记录
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("Delete")]
        public async Task DeleteAsync([FromBody] UpdateUnitCommand command)
        {
            await Mediator.Send(command);
        }
    }
}
