using KaranTeam.Data;
using KaranTeam.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Services
{
    public class FileService : IFileService
    {
        // csak akkor ad vissza jó értéket ez a manager ha authoz van kötve az adott controller elérése
        private IUserManager UserManager { get; }
        private ApplicationDbContext Context { get; }

        public FileService(ApplicationDbContext context,
            IUserManager userManager)
        {
            UserManager = userManager;
            Context = context;
        }

        public async Task<IEnumerable<FileListModel>> GetFiles()
        {
            return await Context.Files.Select(f => new FileListModel(f)).ToListAsync();
        }
    }
}
