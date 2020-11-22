using KaranTeam.Data;
using KaranTeam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Services
{
    public class FajlService : IFajlService
    {
        // csak akkor ad vissza jó értéket ez a manager ha authoz van kötve az adott controller elérése
        private IFelhasznaloManager FelhasznaloManager { get; }
        private ApplicationDbContext Context { get; }

        public FajlService(ApplicationDbContext context,
            IFelhasznaloManager felhasznaloManager)
        {
            FelhasznaloManager = felhasznaloManager;
            Context = context;
        }
    }
}
