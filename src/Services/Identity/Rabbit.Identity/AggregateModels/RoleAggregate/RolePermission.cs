namespace Rabbit.Identity.AggregateModels.RoleAggregate
{
    public class RolePermission : Entity
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public RolePermission(int permissionId)
        {
            PermissionId = permissionId;
        }
    }
}
