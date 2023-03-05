namespace Rabbit.Identity.WebAPI.Application.Queries.Mappings
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Role, RoleModel>()
                 .ForMember(option => option.PermissionIds,
                 dest => dest.MapFrom(src => src.Permissions.Select(s => s.PermissionId)));

            CreateMap<Role, RoleListModel>();
        }
    }
}
