using KaranTeam.Data.Entities;
using KaranTeam.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaranTeam.Services
{
    public interface ICaffFileService
    {
        Task<IEnumerable<FileModel>> GetFileList();
        Task<NewFileModel> UploadFile(NewFileModel newFile);
        Task<FileModel> GetFileById(int fileId);
        Task ModifyFile(FileModel modifiedFile);
        Task RemoveFileById(int fileId);
    }
}