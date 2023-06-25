using AuthAPI.API.RequestModel;
using AuthAPI.Repositories.Interface;
using AuthAPI.Services.Interface;
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
        private readonly IUserServices _userServices;

        public RegistrationAPIController(IUserRepository userRepository, IUserServices userServices)
        {
            _userRepository = userRepository;
            _userServices = userServices;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserModel userDto)
        {
            var existingUser = await _userServices.GetUserByUsername(userDto.Username);
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

            await _userServices.AddUser(user);

            return Ok("User registered successfully.");
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login(UserModel model)
        {
            var user = _userServices.GetUserByUsername(model.Username);

            if (user == null)
            {
                return BadRequest("Invalid username");
            }

            // Perform password validation
           /* if (!IsValidPassword(model.Password, user.Password))
            {
                return BadRequest("Invalid password");
            }*/

            // Generate and return authentication token or perform other login actions

            return Ok("Login successful");
        }

       /* private bool IsValidPassword(string password1, object password2)
        {
            throw new NotImplementedException();
        }*/
    }
}
