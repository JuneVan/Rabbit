namespace Rabbit.Identity.WebAPI.Application.Queries.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserModel>()
                .ForMember(option => option.RoleIds,
                 dest => dest.MapFrom(src => src.Roles.Select(s => s.RoleId)));
            CreateMap<User, UserListModel>();

        }
    }
}
