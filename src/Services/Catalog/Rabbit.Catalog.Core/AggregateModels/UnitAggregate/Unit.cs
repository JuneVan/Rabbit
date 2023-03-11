namespace Rabbit.Catalog.AggregateModels.UnitAggregate
{
    /// <summary>
    /// 计量单位
    /// </summary>
    public class Unit : FullAuditedAggregateRoot
    {
        public Unit(string name, bool isActive)
        {
            SetName(name);
            SetIsActive(isActive);
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; private set; }
        public void SetName(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name), "计量单位名称不能为空。");
            Name = name;
        }

        /// <summary>
        /// 获取是否可用状态
        /// 当不可用时，不能再被引用设置，但不影响已引用的数据
        /// </summary>
        public bool IsActive { get; private set; }
        public void SetIsActive(bool isActive)
        {
            IsActive = isActive;
        }
    }
}
