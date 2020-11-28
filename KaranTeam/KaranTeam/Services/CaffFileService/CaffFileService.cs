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
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;

namespace KaranTeam.Services
{
    public class CaffFileService : ICaffFileService
    {
        private ILoggedInUser UserManager { get; }
        private IWebHostEnvironment Env { get; }
        private ApplicationDbContext Context { get; }

        public CaffFileService(ApplicationDbContext context, ILoggedInUser userManager, IWebHostEnvironment env)
        {
            UserManager = userManager;
            Context = context;
            Env = env;
        }

        public async Task<IEnumerable<FileModel>> GetFileList()
        {
            return await Context.Files.Include(f => f.Owner).Include(f => f.FileComments).ThenInclude(fc => fc.User)
                .Select(f => new FileModel(f))
                .ToListAsync();
        }

        public async Task<NewFileModel> UploadFile(NewFileModel newFile)
        {
            var caffUri = SaveCaffFile(newFile);
            var thumbnailUri = GenerateThumbnail(newFile, caffUri);
            var newEntity = new CaffFile
            {
                CAFFUri = caffUri,
                ThumbnailUri = thumbnailUri,
                Title = newFile.Title,
                Description = newFile.Description,
                OwnerId = UserManager.GetUserId()
            };

            Context.Files.Add(newEntity);
            await Context.SaveChangesAsync();
            return newFile;
        }

        public async Task<FileModel> GetFileDetails(int fileId)
        {
            return await Context.Files.Include(f=>f.Owner).Include(f=>f.FileComments).ThenInclude(fc=>fc.User)
                .Where(f => f.Id == fileId)
                .Select(f => new FileModel(f))
                .SingleOrDefaultAsync();
        }

        public async Task<FileDownloadModel> GetFileDownload(int fileId)
        {
            var file = await Context.Files.SingleOrDefaultAsync(f => f.Id == fileId);
            var fileInfo = new FileInfo(file.CAFFUri);

            return new FileDownloadModel
            {
                Content = File.ReadAllBytes(fileInfo.FullName),
                FileName = fileInfo.Name,
                ContentType = "application/octet-stream"
            };
        }

        public async Task<FileDownloadModel> GetFileThumbnail(int fileId)
        {
            var file = await Context.Files.SingleOrDefaultAsync(f => f.Id == fileId);
            var fileInfo = new FileInfo(file.ThumbnailUri);

            return new FileDownloadModel
            {
                Content = File.ReadAllBytes(fileInfo.FullName),
                FileName = fileInfo.Name,
                ContentType = "image/bmp"
            };
        }

        public async Task ModifyFile(int id, FileModel modifiedFile)
        {
            var user = await Context.Users.Where(u => u.Id == UserManager.GetUserId()).SingleOrDefaultAsync();
            if (user.IsAdmin)
            {
                var file = await Context.Files.SingleOrDefaultAsync(f => f.Id == id);
                file.Title = modifiedFile.Title;
                file.Description = modifiedFile.Description;
                Context.Files.Update(file);
                await Context.SaveChangesAsync();
            }
        }

        public async Task RemoveFileById(int fileId)
        {
            var user = await Context.Users.Where(u => u.Id == UserManager.GetUserId()).SingleOrDefaultAsync();
            if (user.IsAdmin)
            {
                var removableEntity = Context.Files.Find(fileId);
                Context.Files.Remove(removableEntity);
                await Context.SaveChangesAsync();
            }
        }

        // https://stackoverflow.com/a/39394266
        private string SaveCaffFile(NewFileModel newFile)
        {
            var subFolder = @"files\caffs";
            string path = Path.Combine(Env.ContentRootPath, subFolder);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var fileName = $"{Context.Files.Count()}_{newFile.File.Name}";
            string filePath = Path.Combine(path, fileName);

            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                newFile.File.CopyTo(ms);
                fileBytes = ms.ToArray();
                File.WriteAllBytes(filePath, fileBytes);
            }
            return filePath;
        }
        private string GenerateThumbnail(NewFileModel newFile, string uri)
        {
            var subFolder = @"files\thumbnails";
            string path = Path.Combine(Env.ContentRootPath, subFolder);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var fileName = $"{Context.Files.Count()}_{newFile.Title}.bmp";
            string filePath = Path.Combine(path, fileName);

            /*ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = Path.Combine(Env.ContentRootPath, @"Parser\parser.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = uri +" "+ filePath;

            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {
                filePath = "https://via.placeholder.com/150";
            }*/

            return filePath;
        }
    }
}
