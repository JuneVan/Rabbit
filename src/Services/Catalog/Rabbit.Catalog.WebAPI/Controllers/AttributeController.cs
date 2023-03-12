namespace Rabbit.Catalog.WebAPI.Controllers
{
    /// <summary>
    /// 属性管理
    /// </summary>
    [Route("v1/[controller]")]
    public class AttributeController : CatalogControllerBase
    {
        private readonly IAttributeQuerier _attributeQuerier;
        public AttributeController(IServiceProvider serviceProvider, IAttributeQuerier attributeQuerier)
            : base(serviceProvider)
        {
            _attributeQuerier = attributeQuerier;
        }
        /// <summary>
        /// 获取一条属性记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Get/{id}")]
        public async Task<BasicAttributeModel> GetByIdAsync(int id)
        {
            return await _attributeQuerier.GetBasicAttributeByIdAsync(id);
        }
        /// <summary>
        /// 获取属性记录列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<PagedResultDto<AttributeListModel>> GetAllAsync([FromQuery] GetAttributesInput input)
        {
            return await _attributeQuerier.GetAttributesAsync(input);
        }

        /// <summary>
        /// 创建一条基础属性记录
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("CreateBasic")]
        public async Task<int> CreateBasicAsync([FromBody] CreateBasicAttributeCommand command)
        {
            return await Mediator.Send(command);
        }
        /// <summary>
        /// 创建一条销售属性记录
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("CreateSales")]
        public async Task<int> CreateSalesAsync([FromBody] CreateSalesAttributeCommand command)
        {
            return await Mediator.Send(command);
        }
        /// <summary>
        /// 更新一条基础属性记录
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("UpdateBasic")]
        public async Task UpdateBasicAsync([FromBody] UpdateBasicAttributeCommand command)
        {
            await Mediator.Send(command);
        }
        /// <summary>
        /// 更新一条销售属性记录
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("UpdateSales")]
        public async Task UpdateSalesAsync([FromBody] UpdateSalesAttributeCommand command)
        {
            await Mediator.Send(command);
        }
        /// <summary>
        /// 删除一条属性记录
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("Delete")]
        public async Task DeleteAsync([FromBody] DeleteAttributeCommand command)
        {
            await Mediator.Send(command);
        }
    }
}
