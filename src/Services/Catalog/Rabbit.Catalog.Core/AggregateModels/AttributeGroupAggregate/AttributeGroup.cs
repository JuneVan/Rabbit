namespace Rabbit.Catalog.AggregateModels.AttributeGroupAggregate
{
    /// <summary>
    /// 属性分组
    /// </summary>
    public class AttributeGroup : Entity
    {
        public AttributeGroup(string name, int categoryId)
        {
            SetName(name);
            SetCategoryId(categoryId);
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 设置模板名称
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetName(string name)
        {
            if (name == null) throw new ArgumentNullException("name", "属性模板名称不能为空");
            Name = name;
        }
        /// <summary>
        /// 所属分类
        /// </summary>
        public int CategoryId { get; private set; }
        /// <summary>
        /// 设置分类Id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetCategoryId(int categoryId)
        {
            if (categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId), $"分类Id`{categoryId}`无效");
            CategoryId = categoryId;
        }


        private List<AttributeGroupItem> _items = new();
        /// <summary>
        /// 获取模板属性列表
        /// </summary>
        public IReadOnlyCollection<AttributeGroupItem> Items => _items;
        /// <summary>
        /// 添加模板属性
        /// </summary>
        /// <param name="attributeId"></param>
        public void AddItem(int attributeId, int displayOrder)
        {
            _items.Add(new AttributeGroupItem(attributeId, displayOrder));
        }
        public void UpdateItem(int itemId, int displayOrder)
        {
            var item = _items.FirstOrDefault(x => x.Id == itemId);
            if (item != null)
            {
                item.SetDisplayOrder(displayOrder);
            }
        }
        /// <summary>
        /// 移除模板属性
        /// </summary>
        /// <param name="itemId"></param>
        public void RemoveItem(int itemId)
        {
            var item = _items.FirstOrDefault(x => x.Id == itemId);
            if (item != null)
                _items.Remove(item);
        }
    }
}
