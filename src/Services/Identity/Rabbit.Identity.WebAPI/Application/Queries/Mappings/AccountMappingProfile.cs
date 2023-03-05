namespace Rabbit.Identity.WebAPI.Application.Queries.Mappings
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<User, ProfileModel>();
        }
    }
}
