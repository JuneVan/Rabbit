namespace Rabbit.Identity.WebAPI.Application.Queries
{
    public interface IAccountQuerier
    {
        Task<ProfileModel> GetProfileAsync(int userId);
        Task<IEnumerable<string>> GetPermissionsAsync(int userId);
    }
}
