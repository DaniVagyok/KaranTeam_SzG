using KaranTeam.Data;
using KaranTeam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Services
{
    public class FileService : IFileService
    {
        // csak akkor ad vissza jó értéket ez a manager ha authoz van kötve az adott controller elérése
        private IUserManager FelhasznaloManager { get; }
        private ApplicationDbContext Context { get; }

        public FileService(ApplicationDbContext context,
            IUserManager felhasznaloManager)
        {
            FelhasznaloManager = felhasznaloManager;
            Context = context;
        }
    }
}
