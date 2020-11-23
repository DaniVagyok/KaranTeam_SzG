using KaranTeam.Data.Entities;
using KaranTeam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaranTeam.Services
{
    public interface IFileService
    {
        public Task<IEnumerable<FileListModel>> GetFileList();
        public Task<File> UploadFile(FileDetailsModel newFile);
        public Task<FileDetailsModel> GetFileById(int fileId);
        public Task<IActionResult> DownloadFileById(int fileId); // https://stackoverflow.com/a/54298794
        public Task ModifyFile(FileDetailsModel modifiedFile);
        public Task RemoveFileById(int fileId);
    }
}