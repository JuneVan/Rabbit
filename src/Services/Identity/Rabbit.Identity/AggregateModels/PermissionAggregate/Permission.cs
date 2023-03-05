namespace Rabbit.Identity.AggregateModels.PermissionAggregate
{
    public class Permission : FullAuditedAggregateRoot
    {

        /// <summary>
        /// 权限名称（唯一标识符）
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 上级权限
        /// </summary>
        public int? ParentId { get; set; }

        public Permission(string name, string description, int? parentId)
        {
            SetName(name);
            SetDescription(description);
            SetParentId(parentId);
        }
        public void SetName(string name)
        {
            if (name == null) throw new ArgumentNullException("name", "权限名称不能为空。");
            Name = name;
        }
        public void SetDescription(string description)
        {
            Description = description;
        }
        public void SetParentId(int? parentId)
        {
            ParentId = parentId;
        }

    }
}
