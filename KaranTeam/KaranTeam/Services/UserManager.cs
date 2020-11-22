using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KaranTeam.Services
{
    public class UserManager : IUserManager
    {
        private readonly IHttpContextAccessor HttpContextAccessor;
        public UserManager(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            var userId = HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if ( userId != null)
                return userId;
            else
                return "";
        }
    }
}
