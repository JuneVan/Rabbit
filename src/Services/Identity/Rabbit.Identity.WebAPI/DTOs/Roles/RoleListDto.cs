namespace Rabbit.Identity.WebAPI.DTOs.Roles
{
    public class RoleListDto : EntityDto
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public bool IsSystemRole { get; set; }
    }
}
