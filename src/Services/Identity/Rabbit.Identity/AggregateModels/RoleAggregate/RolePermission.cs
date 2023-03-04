namespace Rabbit.Identity.AggregateModels.RoleAggregate
{
    public class RolePermission : Entity
    {
        private int _permissionId;
        public RolePermission(int permissionId)
        {
            _permissionId = permissionId;
        }
    }
}
