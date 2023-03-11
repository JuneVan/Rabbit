namespace Rabbit.Catalog.WebAPI.Application.Queries.Models
{
    public class AttributeGroupModel
    {
        public int Id { get; set; }
        /// <summary>
        /// 获取名称
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 获取所属分类
        /// </summary>
        public int CategoryId { get; private set; } 
        /// <summary>
        /// 获取属性列表
        /// </summary>
        public List<AttributeGroupItemModel> Items { get; set; }
    }
     
    public class AttributeGroupItemModel
    {
        /// <summary>
        /// 属性Id
        /// </summary>
        public int AttributeId { get; set; }

        /// <summary>
        /// 属性分组
        /// </summary>
        public int AttributeGroupId { get; set; } 
    }
}
