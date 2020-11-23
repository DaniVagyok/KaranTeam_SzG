using KaranTeam.Data.Entities;
using KaranTeam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaranTeam.Services
{
    public interface IFileService
    {
        public Task<IEnumerable<FileModel>> GetFiles();
        public Task<File> UploadFile(FileModel newFile);
        public Task<FileModel> GetFileById(int fileId);
        public Task<IActionResult> DownloadFileById(int fileId); // https://stackoverflow.com/a/54298794
        public Task ModifyFile(FileModel modifiedFile);
        public Task RemoveFileById(int fileId);
    }
}