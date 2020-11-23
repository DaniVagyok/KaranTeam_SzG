using KaranTeam.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Services
{
    public class UserService : IUserService
    {
        private IUserManager FelhasznaloManager { get; }
        private ApplicationDbContext Context { get; }

        public UserService(ApplicationDbContext context,
            IUserManager felhasznaloManager)
        {
            FelhasznaloManager = felhasznaloManager;
            Context = context;
        }
    }
}
