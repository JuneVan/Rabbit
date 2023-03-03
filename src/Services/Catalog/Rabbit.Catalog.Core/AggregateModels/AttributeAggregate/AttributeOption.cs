namespace Rabbit.Catalog.AggregateModels.AttributeAggregate
{
    /// <summary>
    /// 属性选项
    /// </summary>
    public class AttributeOption : Entity
    {
        private string _name;
        private int _displayOrder;
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
            if (name == null) throw new ArgumentNullException("name", "属性选项名称不能为空");
            _name = name;
        }
        /// <summary>
        /// 设置排序值
        /// </summary>
        /// <param name="displayOrder"></param>
        public void SetDisplayOrder(int displayOrder)
        {
            _displayOrder = displayOrder;
        }
    }
}
