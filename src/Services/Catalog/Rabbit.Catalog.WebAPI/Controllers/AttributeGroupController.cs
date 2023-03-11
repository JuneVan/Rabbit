namespace Rabbit.Catalog.WebAPI.Controllers
{
    /// <summary>
    /// 属性分组管理
    /// </summary>
    [Route("v1/[controller]")]
    public class AttributeGroupController : CatalogControllerBase
    {
        private readonly IAttributeGroupQuerier  _templateQuerier;
        public AttributeGroupController(IServiceProvider serviceProvider,
            IAttributeGroupQuerier templateQuerier)
            : base(serviceProvider)
        {
            _templateQuerier = templateQuerier;
        }
        /// <summary>
        /// 获取一条属性分组记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Get/{id}")]
        public async Task<AttributeGroupModel> GetByIdAsync(int id)
        {
            return await _templateQuerier.GetAttributeGroupByIdAsync(id);
        }
        /// <summary>
        /// 获取属性分组记录列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("GetAttributeGroups")]
        public async Task<PagedResultDto<AttributeGroupListModel>> GetAttributeGroupsAsync(GetAttributeGroupsInput input)
        {
            return await _templateQuerier.GetAttributeGroupsAsync(input);
        }
      
        /// <summary>
        /// 创建一条属性分组记录
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<int> CreateAsync([FromBody] CreateAttributeGroupCommand command)
        {
            return await Mediator.Send(command);
        }
        /// <summary>
        /// 更新一条属性分组记录
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public async Task UpdateAsync([FromBody] UpdateAttributeGroupCommand command)
        {
            await Mediator.Send(command);
        }
        /// <summary>
        /// 删除一条属性分组记录
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("Delete")]
        public async Task DeleteAsync([FromBody] UpdateAttributeGroupCommand command)
        {
            await Mediator.Send(command);
        }
    }
}
