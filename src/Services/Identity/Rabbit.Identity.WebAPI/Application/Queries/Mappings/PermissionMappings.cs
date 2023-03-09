namespace Rabbit.Identity.WebAPI.Application.Queries.Mappings
{
    public class PermissionMappings : Profile
    {
        public PermissionMappings()
        {
            CreateMap<Permission, PermissionModel>();
        }
    }
}
