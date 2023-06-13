using AuthAPI.API.RequestModel;

namespace AuthAPI.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<UserModel> GetUserByUsername(string username);
        Task CreateUser(UserModel user);
    }
}
