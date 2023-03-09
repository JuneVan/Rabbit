namespace Rabbit.Catalog.AggregateModels.AttributeAggregate
{
    /// <summary>
    /// 属性
    /// </summary>
    public class Attribute : Entity
    {
        public string Name { get; private set; }
        public bool IsRequired { get; private set; }
        public int DisplayOrder { get; private set; }
        public AttributeDisplayType DisplayType { get; private set; }

        private List<AttributeOption> _options = new();
        public IReadOnlyList<AttributeOption> Options => _options;

        public Attribute(string name, bool isRequired, int displayOrder, AttributeDisplayType displayType)
        {
            SetName(name);
            SetIsRequired(isRequired);
            SetDisplayOrder(displayOrder);
            SetDisplayType(displayType);
        }
        public void SetName(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name), "属性名称不能为空");
            Name = name;
        }
        /// <summary>
        /// 设置是否必填
        /// </summary>
        /// <param name="isRequired">是否必填</param>
        public void SetIsRequired(bool isRequired)
        {
            IsRequired = isRequired;
        }
        /// <summary>
        /// 设置排序值
        /// </summary>
        /// <param name="displayOrder">排序值</param>
        public void SetDisplayOrder(int displayOrder)
        {
            DisplayOrder = displayOrder;
        }

        public void SetDisplayType(AttributeDisplayType displayType)
        {
            DisplayType = displayType;
        }
        /// <summary>
        /// 添加选项
        /// </summary>
        /// <param name="name"></param>
        /// <param name="displayOrder"></param>
        public void AddOption(string name, int displayOrder)
        {
            _options.Add(new AttributeOption(name, displayOrder));
        }
        /// <summary>
        /// 移除选项
        /// </summary>
        /// <param name="id">id</param>
        public void RemoveOption(int id)
        {
            var option = _options.FirstOrDefault(x => x.Id == id);
            if (option != null) { _options.Remove(option); }
        }
        /// <summary>
        /// 更新选项
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="name">选项名</param>
        /// <param name="displayOrder">排序值</param>
        public void UpdateOption(int id, string name, int displayOrder)
        {
            var option = _options.FirstOrDefault(x => x.Id == id);
            if (option == null)
                throw new ArgumentException($"选项Id`{id}`不存在");
            option.SetName(name);
            option.SetDisplayOrder(displayOrder);
        }
    }
}
