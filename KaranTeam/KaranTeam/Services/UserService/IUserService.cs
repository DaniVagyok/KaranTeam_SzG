using KaranTeam.Models;
using System.Threading.Tasks;

namespace KaranTeam.Services
{
    public interface IUserService
    {
        public Task<UserDetailsModel> GetUserById(int userId);
        public Task ModifyUser(UserDetailsModel modifiedUser);
    }
}