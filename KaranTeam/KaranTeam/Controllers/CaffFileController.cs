using KaranTeam.Models;
using KaranTeam.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/caff")]
    [ApiController]
    [Authorize]
    public class CaffFileController : ControllerBase
    {
        public ICaffFileService CaffFileService { get; }
        public CaffFileController(ICaffFileService caffFileService)
        {
            CaffFileService = caffFileService;
        }

        [HttpGet]
        public async Task<IEnumerable<FileModel>> GetCaffFiles() => await CaffFileService.GetFileList();

        [HttpGet("{id}")]
        public async Task<FileModel> GetFileById(int fileId) => await CaffFileService.GetFileById(fileId);

        [HttpPut("{id}")]
        public async Task ModifyFile(FileModel modifiedFile) => await CaffFileService.ModifyFile(modifiedFile);

        [HttpDelete("{id}")]
        public async Task DeleteFile(int fileId) => await CaffFileService.RemoveFileById(fileId);

        // TODO: Change to form data
        [HttpPost]
        public async Task<NewFileModel> UploadFile(NewFileModel newFile) => await CaffFileService.UploadFile(newFile);

        // https://stackoverflow.com/a/3605510
        [HttpGet("{id}")]
        public async Task<FileResult> DownloadCaffFile(int fileUri)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes($"{fileUri}");
            string fileName = "cool.caff";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

    }
}
