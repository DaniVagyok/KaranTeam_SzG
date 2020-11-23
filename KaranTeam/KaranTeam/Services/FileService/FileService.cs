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
using System.IO;

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

        public async Task<IEnumerable<FileModel>> GetFileList()
        {
            return await Context.Files
                .Select(f => new FileModel(f))
                .ToListAsync();
        }

        public async Task<NewFileModel> UploadFile(NewFileModel newFile)
        {
            var caffUri = SaveCaffFile(newFile);
            var newEntity = new Data.Entities.File
            {
                Id = newFile.Id,
                CAFFUri = caffUri,
                Title = newFile.Title,
                Description = newFile.Description,
                OwnerId = UserManager.GetUserId()
            };

            Context.Files.Add(newEntity);
            await Context.SaveChangesAsync();
            return newFile;
        }

        public async Task<FileModel> GetFileById(int fileId)
        {
            return await Context.Files
                .Where(f => f.Id == fileId)
                .Select(f => new FileModel(f))
                .SingleOrDefaultAsync();
        }

        public async Task ModifyFile(FileModel modifiedFile)
        {
            var modifiedEntity = modifiedFile.ToEntity(UserManager.GetUserId());
            Context.Files.Update(modifiedEntity);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveFileById(int fileId)
        {
            var removableEntity = Context.Files.Find(fileId);
            Context.Files.Remove(removableEntity);
            await Context.SaveChangesAsync();
        }

        // https://stackoverflow.com/a/39394266
        private string SaveCaffFile(NewFileModel newFile)
        {
            string path = "~/files/caffs";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path); //Create directory if it doesn't exist
            }

            var fileName = $"{newFile.Title}_{Context.Files.Count()}.caff";
            string filePath = Path.Combine(path, fileName);
            byte[] fileBytes = Convert.FromBase64String(newFile.FileBase64String);

            System.IO.File.WriteAllBytes(filePath, fileBytes);

            return filePath;
        }
    }
}
