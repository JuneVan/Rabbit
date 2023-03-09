namespace Rabbit.Catalog.AggregateModels.TemplateAggregate
{
    /// <summary>
    /// 属性模板项
    /// </summary> 
    public class TemplateGroup : Entity
    {
        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupName { get; private set; }
        /// <summary>
        /// 排序值
        /// </summary>
        public int DisplayOrder { get; private set; }
        /// <summary>
        /// 模板Id
        /// </summary>
        public int TemplateId { get; private set; }

        private List<TemplateGroupItem> _items = new();
        public IReadOnlyCollection<TemplateGroupItem> Items => _items;

        public TemplateGroup(string groupName, int displayOrder)
        {
            SetName(groupName);
            SetDisplayOrder(displayOrder);
        }
        public void SetName(string groupName)
        {
            if (groupName == null) throw new ArgumentNullException(nameof(groupName), "属性分组不能为空。");
            GroupName = groupName;
        }
        public void SetDisplayOrder(int displayOrder)
        {
            DisplayOrder = displayOrder;
        }

    }
}
