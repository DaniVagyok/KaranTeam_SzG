using KaranTeam.Data;
using KaranTeam.Data.Entities;
using KaranTeam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace KaranTeam.Services
{
    public class FileService : IFileService
    {
        private IUserManager UserManager { get; }
        private ApplicationDbContext Context { get; }

        public FileService(ApplicationDbContext context, IUserManager userManager)
        {
            UserManager = userManager;
            Context = context;
        }

        public async Task<IEnumerable<FileListModel>> GetFileList()
        {
            return await Context.Files
                .Select(f => new FileListModel(f))
                .ToListAsync();
        }

        public async Task<File> UploadFile(FileDetailsModel newFile)
        {
            // TODO: Mit kéne itt átadni paraméterként?
            var newEntity = newFile.ToEntity();
            newEntity.OwnerId = UserManager.GetUserId();

            var result = Context.Files.Add(newEntity);
            await Context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<FileDetailsModel> GetFileById(int fileId)
        {
            return await Context.Files
                .Where(f => f.Id == fileId)
                .Select(f => new FileDetailsModel(f))
                .SingleOrDefaultAsync();
        }

        public async Task DownloadFileById(int fileId)
        {
            var downloadPath = Context.Files.Where(f => f.Id == fileId).SingleOrDefault().CAFFUri;
            var downloadUri = new Uri(downloadPath);
            var client = new WebClient();
            await client.DownloadFileTaskAsync(downloadUri, "fileName.caff");
 ;        }

        public async Task ModifyFile(FileDetailsModel modifiedFile)
        {
            var modifiedEntity = modifiedFile.ToEntity();
            modifiedEntity.OwnerId = UserManager.GetUserId();

            Context.Files.Update(modifiedEntity);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveFileById(int fileId)
        {
            var removableEntity = Context.Files.Find(fileId);
            Context.Files.Remove(removableEntity);
            await Context.SaveChangesAsync();
        }
    }
}
