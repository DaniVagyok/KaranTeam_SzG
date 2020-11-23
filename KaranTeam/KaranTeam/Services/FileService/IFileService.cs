using KaranTeam.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaranTeam.Services
{
    public interface IFileService
    {
        public Task<IEnumerable<FileListModel>> GetFiles();
        public Task<FileListModel> addFile(string fileUri);
        public Task<FileListModel> getFileById(string fileId);
        public Task<IActionResult> downloadFileById(string fileId); // https://stackoverflow.com/a/54298794
        public Task modifyFileById(string fileId, FileListModel modifiedFile);
    }
}