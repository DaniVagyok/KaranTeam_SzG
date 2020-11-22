using KaranTeam.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Services
{
    public class FelhasznaloService : IFelhasznaloService
    {
        private IUserManager FelhasznaloManager { get; }
        private ApplicationDbContext Context { get; }

        public FelhasznaloService(ApplicationDbContext context,
            IUserManager felhasznaloManager)
        {
            FelhasznaloManager = felhasznaloManager;
            Context = context;
        }
    }
}
