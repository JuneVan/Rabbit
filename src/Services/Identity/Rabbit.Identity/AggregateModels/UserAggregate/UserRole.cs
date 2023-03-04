namespace Rabbit.Identity.AggregateModels.UserAggregate
{
    public class UserRole : Entity
    {
        private int _roleId;
        public UserRole(int roleId)
        {
            _roleId = roleId;
        }
    }
}
