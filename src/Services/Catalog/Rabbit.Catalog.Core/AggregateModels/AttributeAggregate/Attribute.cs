namespace Rabbit.Catalog.AggregateModels.AttributeAggregate
{
    /// <summary>
    /// 属性
    /// </summary>
    public class Attribute : FullAuditedAggregateRoot
    {
        public Attribute() { }
        /// <summary>
        /// 创建基础属性
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="isRequired">是否必填</param>
        /// <param name="displayOrder">排序</param>
        /// <param name="valueType">值的类型</param>
        /// <param name="controlType">控件的类型</param>
        /// <param name="description">描述</param>
        /// <param name="isSearch">是否可搜索</param>
        /// <param name="unitId">计量单位Id</param>
        /// <param name="isActive">是否可用</param>
        /// <param name="categoryId">分类Id</param>
        /// <returns></returns>
        public static Attribute CreateBasicAttribute(string name, bool isRequired, int displayOrder, AttributeValueType valueType, AttributeControlType controlType, string description, bool isSearch, int? unitId, bool isActive, int categoryId)
        {
            var attribute = new Attribute();
            attribute.SetName(name);
            attribute.SetIsRequired(isRequired);
            attribute.SetValueType(valueType);
            attribute.SetDisplayOrder(displayOrder);
            attribute.SetControlType(controlType);
            attribute.SetDescription(description);
            attribute.SetIsSearch(isSearch);
            attribute.SetUnitId(unitId);
            attribute.SetIsActive(isActive);
            attribute.SetCategoryId(categoryId);
            attribute.SetAttributeType(AttributeType.Basic);
            return attribute;
        }
        /// <summary>
        /// 创建销售属性
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="displayOrder">排序</param>
        /// <param name="description">描述</param>
        /// <param name="isActive">是否可用</param>
        /// <param name="categoryId">分类Id</param>
        /// <returns></returns>
        public static Attribute CreateSalesAttribute(string name, int displayOrder, string description, bool isActive, int categoryId)
        {
            var attribute = new Attribute();
            attribute.SetName(name);
            attribute.SetValueType(AttributeValueType.Option);
            attribute.SetDisplayOrder(displayOrder);
            attribute.SetDescription(description);
            attribute.SetIsSearch(true);
            attribute.SetIsActive(isActive);
            attribute.SetCategoryId(categoryId);
            attribute.SetAttributeType(AttributeType.Sales);
            return attribute;
        }

        /// <summary>
        /// 获取名称
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 设置名称
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void SetName(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name), "属性名称不能为空");
            Name = name;
        }
        /// <summary>
        /// 是否必填
        /// </summary>
        public bool IsRequired { get; private set; }
        /// <summary>
        /// 设置是否必填
        /// </summary>
        /// <param name="isRequired">是否必填</param>
        public void SetIsRequired(bool isRequired)
        {
            IsRequired = isRequired;
        }
        /// <summary>
        /// 显示顺序
        /// </summary>
        public int DisplayOrder { get; private set; }
        /// <summary>
        /// 设置排序值
        /// </summary>
        /// <param name="displayOrder">排序值</param>
        public void SetDisplayOrder(int displayOrder)
        {
            DisplayOrder = displayOrder;
        }
        /// <summary>
        /// 属性值类型
        /// </summary>
        public AttributeValueType ValueType { get; private set; }
        public void SetValueType(AttributeValueType valueType)
        {
            ValueType = valueType;
        }
        /// <summary>
        /// 获取控件类型
        /// </summary>
        public AttributeControlType ControlType { get; private set; }
        /// <summary>
        /// 设置控件类型
        /// </summary>
        /// <param name="controlType"></param>
        public void SetControlType(AttributeControlType controlType)
        {
            ControlType = controlType;
        }
        /// <summary>
        /// 获取描述说明
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// 设置描述说明
        /// </summary>
        /// <param name="description"></param>
        public void SetDescription(string description)
        {
            Description = description;
        }
        /// <summary>
        /// 获取是否参与搜索
        /// </summary>
        public bool IsSearch { get; private set; }
        /// <summary>
        /// 设置是否参与搜索
        /// </summary>
        /// <param name="isSearch"></param>
        public void SetIsSearch(bool isSearch)
        {
            IsSearch = isSearch;
        }

        private List<AttributeOption> _options = new();
        /// <summary>
        /// 获取属性的选项列表
        /// </summary>
        public IReadOnlyList<AttributeOption> Options => _options;

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
        /// <exception cref="ArgumentException"></exception>
        public void UpdateOption(int id, string name, int displayOrder)
        {
            var option = _options.FirstOrDefault(x => x.Id == id);
            if (option == null)
                throw new ArgumentException($"选项Id`{id}`不存在");
            option.SetName(name);
            option.SetDisplayOrder(displayOrder);
        }
        /// <summary>
        /// 获取计量单位
        /// </summary>
        public int? UnitId { get; private set; }
        /// <summary>
        /// 设置计量单位
        /// </summary>
        /// <param name="unitId"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetUnitId(int? unitId)
        {
            if (unitId.HasValue && unitId <= 0)
                throw new ArgumentOutOfRangeException(nameof(unitId), "无效计量单位Id。");
            UnitId = unitId;
        }
        /// <summary>
        /// 获取是否可用状态
        /// 当不可用时，不能再被引用设置，但不影响已引用的数据
        /// </summary>
        public bool IsActive { get; private set; }
        /// <summary>
        /// 设置是否可用
        /// </summary>
        /// <param name="isActive"></param>
        public void SetIsActive(bool isActive)
        {
            IsActive = isActive;
        }
        /// <summary>
        /// 获取分类Id
        /// </summary>
        public int CategoryId { get; private set; }
        /// <summary>
        /// 设置分类Id
        /// </summary>
        /// <param name="categoryId"></param>
        internal void SetCategoryId(int categoryId)
        {
            CategoryId = categoryId;
        }
        /// <summary>
        /// 获取属性类型
        /// </summary>
        public AttributeType AttributeType { get; private set; }
        /// <summary>
        /// 设置属性类型
        /// </summary>
        /// <param name="attributeType"></param>
        internal void SetAttributeType(AttributeType attributeType)
        {
            AttributeType = attributeType;
        }
    }
}
