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
        public async Task<AttributeModel> GetByIdAsync(int id)
        {
            return await _attributeQuerier.GetAttributeByIdAsync(id);
        }
        /// <summary>
        /// 获取属性记录列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("GetAttributes")]
        public async Task<PagedResultDto<AttributeListModel>> GetAttributesAsync(GetAttributesInput input)
        {
            return await _attributeQuerier.GetAttributesAsync(input);
        }
   
        /// <summary>
        /// 创建一条属性记录
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<int> CreateAsync([FromBody] CreateAttributeCommand command)
        {
            return await Mediator.Send(command);
        }
        /// <summary>
        /// 更新一条属性记录
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public async Task UpdateAsync([FromBody] UpdateAttributeCommand command)
        {
            await Mediator.Send(command);
        }
        /// <summary>
        /// 删除一条属性记录
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("Delete")]
        public async Task DeleteAsync([FromBody] UpdateAttributeCommand command)
        {
            await Mediator.Send(command);
        }
    }
}
