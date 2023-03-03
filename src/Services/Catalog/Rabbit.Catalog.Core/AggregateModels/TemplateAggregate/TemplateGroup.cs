namespace Rabbit.Catalog.AggregateModels.TemplateAggregate
{
    /// <summary>
    /// 属性模板分组
    /// </summary>
    public class TemplateGroup : Entity
    {
        private string _name;
        private int _displayOrder;

        public TemplateGroup(string name, int displayOrder)
        {
            SetName(name);
            SetDisplayOrder(displayOrder);
        }
        public void SetName(string name)
        {
            if (name == null) throw new ArgumentNullException("name", "属性分组不能为空");
            _name = name;
        }
        public void SetDisplayOrder(int displayOrder)
        {
            _displayOrder = displayOrder;
        }
    }
}
