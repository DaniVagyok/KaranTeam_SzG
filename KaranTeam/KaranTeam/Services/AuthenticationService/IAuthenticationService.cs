using KaranTeam.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace KaranTeam.Services
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> Register(LoginModel model);
        Task<string> Login(LoginModel model);
        Task Logout();
    }
}