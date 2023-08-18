using AuthAPI.API.RequestModel;
using AuthAPI.Data;
using AuthAPI.Repositories.Interface;
using AuthAPI.Services.Implementation;
using AuthAPI.Services.Interface;
using Azure;
using Microsoft.EntityFrameworkCore;

namespace AuthAPI.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel> GetUserByUsername(string? username)
        {
            try
            {
                var user =  await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task CreateUser(UserModel user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
