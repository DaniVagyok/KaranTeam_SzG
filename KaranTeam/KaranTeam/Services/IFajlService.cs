using KaranTeam.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaranTeam.Services
{
    public interface IFajlService
    {
        Task<IEnumerable<FajlListaModel>> GetFajlok(string szuro);
    }
}