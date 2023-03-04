namespace Rabbit.Identity.WebAPI.DTOs.Roles
{
    public class RoleDto : EntityDto
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }
        public List<int> PermissionIds { get; set; }
    }
}
