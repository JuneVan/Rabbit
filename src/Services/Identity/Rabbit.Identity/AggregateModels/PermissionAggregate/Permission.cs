namespace Rabbit.Identity.AggregateModels.PermissionAggregate
{
    public class Permission : FullAuditedAggregateRoot
    {

        // 权限名称（唯一标识符）
        private string _name;
        public string Name => _name;
        // 描述
        private string _description;
        // 上级权限Id
        private int? _parentId;

        public Permission(string name, string description, int? parentId)
        {
            SetName(name);
            SetDescription(description);
            SetParentId(parentId);
        }
        public void SetName(string name)
        {
            if (name == null) throw new ArgumentNullException("name", "权限名称不能为空。");
            _name = name;
        }
        public void SetDescription(string description)
        {
            _description = description;
        }
        public void SetParentId(int? parentId)
        {
            _parentId = parentId;
        }

    }
}
