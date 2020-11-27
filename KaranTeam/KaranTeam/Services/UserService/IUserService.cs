using KaranTeam.Models;
using System.Threading.Tasks;

namespace KaranTeam.Services
{
    public interface IUserService
    {
        Task<UserDetailsModel> GetUserById(int userId);
        Task ModifyUser(UserDetailsModel modifiedUser);
        bool IsAdmin();
    }
}