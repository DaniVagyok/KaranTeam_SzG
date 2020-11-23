using KaranTeam.Data.Entities;
using KaranTeam.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaranTeam.Services
{
    public interface IFileService
    {
        public Task<IEnumerable<FileListModel>> GetFileList();
        public Task<File> UploadFile(NewFileModel newFile);
        public Task<FileDetailsModel> GetFileById(int fileId);
        public Task ModifyFile(FileDetailsModel modifiedFile);
        public Task RemoveFileById(int fileId);
    }
}