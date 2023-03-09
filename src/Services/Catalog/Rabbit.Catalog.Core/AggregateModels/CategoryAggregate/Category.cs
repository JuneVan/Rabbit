namespace Rabbit.Catalog.AggregateModels.CategoryAggregate
{
    /// <summary>
    /// 分类
    /// </summary>
    public class Category : FullAuditedAggregateRoot
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 上级Id
        /// </summary>
        public int? ParentId { get; private set; }
        /// <summary>
        /// 上级分类
        /// </summary>
        public Category Parent { get; private set; }


        private List<Category> _children = new();
        /// <summary>
        /// 下级分类集合
        /// </summary>
        public IReadOnlyCollection<Category> Children => _children.AsReadOnly();
        /// <summary>
        /// 排序
        /// </summary>
        public int DisplayOrder { get; private set; }
        public Category(string name, int displayOrder)
        {
            SetName(name);
            SetDisplayOrder(displayOrder);
        }
        public void SetName(string name)
        {
            if (name == null) throw new ArgumentNullException("name", "分类名称不能为空");
            Name = name;
        }
        public void SetParent(Category parent)
        {
            Parent = parent;
        }
        public void SetDisplayOrder(int displayOrder)
        {
            DisplayOrder = displayOrder;
        }

    }
}
