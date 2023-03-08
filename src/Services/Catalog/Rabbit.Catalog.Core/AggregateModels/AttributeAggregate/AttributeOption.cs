namespace Rabbit.Catalog.AggregateModels.AttributeAggregate
{
    /// <summary>
    /// 属性选项
    /// </summary>
    public class AttributeOption : Entity
    {
       public string Name { get;private set; }
       public int DisplayOrder { get;private set; } 
       public int AttributeId { get;private set; }
        public AttributeOption(string name, int displayOrder)
        {
            SetName(name);
            SetDisplayOrder(displayOrder);
        }
        /// <summary>
        /// 设置选项名称
        /// </summary>
        /// <param name="name">名称</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetName(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name), "属性选项名称不能为空");
            Name = name;
        }
        /// <summary>
        /// 设置排序值
        /// </summary>
        /// <param name="displayOrder"></param>
        public void SetDisplayOrder(int displayOrder)
        {
            DisplayOrder = displayOrder;
        }
    }
}
