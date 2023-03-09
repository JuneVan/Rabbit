namespace Rabbit.Identity.WebAPI.Application.Queries.Mappings
{
    public class RoleMappings : Profile
    {
        public RoleMappings()
        {
            CreateMap<Role, RoleModel>()
                 .ForMember(option => option.PermissionIds,
                 dest => dest.MapFrom(src => src.Permissions.Select(s => s.PermissionId)));

            CreateMap<Role, RoleListModel>();
        }
    }
}
