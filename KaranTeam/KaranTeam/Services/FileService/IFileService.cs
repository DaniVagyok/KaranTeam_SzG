using KaranTeam.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaranTeam.Services
{
    public interface IFileService
    {
        public Task<IEnumerable<FileListModel>> GetFiles();
    }
}