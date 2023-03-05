namespace Rabbit.Identity.WebAPI.Application.Queries.Models
{
    public class RoleModel
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<int> PermissionIds { get; set; }
    }
}
