using AuthAPI.API.RequestModel;

namespace AuthAPI.Services.Interface
{
    public interface IUserServices
    {
        Task<UserModel> GetUserByUsername(string username);
        void AddUser(UserModel user);
    }
}
