namespace Rabbit.Identity.WebAPI.Application.Queries.Models
{
    public class RoleListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public bool IsSystemRole { get; set; }
    }
}
