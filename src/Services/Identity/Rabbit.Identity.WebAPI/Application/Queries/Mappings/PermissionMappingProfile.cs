namespace Rabbit.Identity.WebAPI.Application.Queries.Mappings
{
    public class PermissionMappingProfile : Profile
    {
        public PermissionMappingProfile()
        {
            CreateMap<Permission, PermissionModel>();
        }
    }
}
