using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.CurrentUser
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var userIdClaim = httpContextAccessor.HttpContext?.User?.FindFirst("UserId");
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out var userId))
            {
                UserId = userId;
            }
            else
            {
                UserId = null; // or set a default value if necessary
            }

            // Retrieve UserName from claims (replace "name" with the actual claim type for the user's name)
            var userNameClaim = httpContextAccessor.HttpContext?.User?.FindFirst("Username");
            UserName = userNameClaim?.Value;

            var emailClaim = httpContextAccessor.HttpContext?.User.FindFirst("Email");
            Email = emailClaim?.Value.ToString();
        }
        public int? UserId { get; }
        public string? UserName { get; }
        public string? Email { get; }
    }
}
