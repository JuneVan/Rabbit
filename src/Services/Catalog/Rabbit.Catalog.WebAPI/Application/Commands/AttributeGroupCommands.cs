namespace Rabbit.Catalog.WebAPI.Application.Commands
{
    public class CreateAttributeGroupCommand : IRequest<int>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 所属分类
        /// </summary>
        public int CategoryId { get; set; } 
        /// <summary>
        /// 属性列表
        /// </summary>

        public List<AttributeGroupItemModel> Items { get; set; }
    }
    public class UpdateAttributeGroupCommand : IRequest
    {
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 所属分类
        /// </summary>
        public int CategoryId { get; set; } 
        /// <summary>
        /// 属性列表
        /// </summary>

        public List<AttributeGroupItemModel> Items { get; set; }
    }
    public class DeleteAttributeGroupCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class AttributeGroupItemModel
    {
        /// <summary>
        /// 属性Id
        /// </summary>
        public int AttributeId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}
