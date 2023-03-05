namespace Rabbit.Identity.WebAPI.Application.Queries
{
    public class AccountQuerier : IAccountQuerier
    {
        public Task<IEnumerable<string>> GetPermissionsAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<ProfileModel> GetProfileAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
