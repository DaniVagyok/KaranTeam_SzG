using KaranTeam.Models;
using KaranTeam.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KaranTeam.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        public IUserService UserService { get; }
        public UserController(IUserService service)
        {
            UserService = service;
        }

        [HttpGet]
        public async Task<UserDetailsModel> GetUser() => await UserService.GetUserById();
        [HttpGet("{id}")]
        public async Task<UserDetailsModel> GetUser(int id) => await UserService.GetUserById(id);

        [HttpPut("{id}")]
        public async Task ModifyUser(UserDetailsModel modifiedUser) => await UserService.ModifyUser(modifiedUser);
    }
}
