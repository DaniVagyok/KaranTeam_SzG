using KaranTeam.Data;
using KaranTeam.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Services
{
    public class UserService : IUserService
    {
        private ILoggedInUser UserManager { get; }
        private ApplicationDbContext Context { get; }

        public UserService(ApplicationDbContext context,
            ILoggedInUser userManager)
        {
            UserManager = userManager;
            Context = context;
        }


        public async Task<UserDetailsModel> GetUserById()
        {
            return await Context.Users
                 .Where(u => u.Id.Equals(UserManager.GetUserId()))
                 .Select(u => new UserDetailsModel(u))
                 .SingleOrDefaultAsync();
        }
        public async Task<UserDetailsModel> GetUserById(int userId)
        {
            return await Context.Users
                 .Where(u => u.Id.Equals(userId))
                 .Select(u => new UserDetailsModel(u))
                 .SingleOrDefaultAsync();
        }

        public async Task ModifyUser(UserDetailsModel modifiedUser)
        {
            var modifiedEntity = modifiedUser.ToEntity();
            Context.Users.Update(modifiedEntity);
            await Context.SaveChangesAsync();
        }

        public bool IsAdmin()
        {
            var user = Context.Users.Where(u => u.Id == UserManager.GetUserId()).SingleOrDefault();
            if (user.IsAdmin)
                return true;
            return false;
        }
    }
}
