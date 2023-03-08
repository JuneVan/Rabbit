namespace Rabbit.Identity.AggregateModels.UserAggregate
{
    public class UserRole : Entity
    {
        public int RoleId { get; private set; }
        public int UserId { get; private set; }
        public UserRole(int roleId)
        {
            RoleId = roleId;
        }
    }
}
