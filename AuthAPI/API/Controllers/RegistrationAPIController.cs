using AuthAPI.API.RequestModel;
using AuthAPI.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationAPIController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public RegistrationAPIController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserModel userDto)
        {
            var existingUser = await _userRepository.GetUserByUsername(userDto.Username);
            if (existingUser != null)
            {
                return BadRequest("Username is already taken.");
            }

            var user = new UserModel
            {
                Username = userDto.Username,
                Password = userDto.Password
                // Set other properties as needed
            };

            await _userRepository.CreateUser(user);

            return Ok("User registered successfully.");
        }
    }
}
