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

        public async Task<IEnumerable<FajlListaModel>> GetFajlok(string szuro)
        {
            /*var user = Context.Users.Where(u=> u.Id == FelhasznaloManager.GetUserId()).SingleOrDefault();
            if (user.IsAdmin)
                return null;
                
            return await Context.Fajlok.Where(f=>f.Nev.Contains(szuro)).ToListAsync().MapTo(f=> new FajlListaModel
            {
            Nev = f.Nev,
            .
            .
            .
            .
            .
            });*/
        }
    }
}
