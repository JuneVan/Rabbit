namespace Rabbit.Identity.WebAPI.Application.Queries.Mappings
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<User, UserModel>()
                .ForMember(option => option.RoleIds,
                 dest => dest.MapFrom(src => src.Roles.Select(s => s.RoleId)));
            CreateMap<User, UserListModel>();

        }
    }
}
