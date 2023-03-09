namespace Rabbit.Identity.WebAPI.Application.Queries.Mappings
{
    public class AccountMappings : Profile
    {
        public AccountMappings()
        {
            CreateMap<User, ProfileModel>();
        }
    }
}
