using AuthAPI.API.RequestModel;
using AuthAPI.Data;
using AuthAPI.Repositories.Implementation;
using AuthAPI.Repositories.Interface;
using AuthAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Services.Implementation
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepo;

        public UserServices(IUserRepository userRepo) 
        {
            _userRepo= userRepo;
        }

        public async Task<UserModel> GetUserByUsername(string username)
        {
            var user =  await _userRepo.GetUserByUsername(username);
            return user;
        }

        public void AddUser(UserModel user)
        {
            _userRepo.CreateUser(user);
        }
    }
}
