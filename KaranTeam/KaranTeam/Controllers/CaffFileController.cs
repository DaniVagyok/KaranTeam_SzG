using KaranTeam.Models;
using KaranTeam.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<FileModel> GetFileDetailsById(int id) => await CaffFileService.GetFileDetails(id);

        [HttpGet("{id/download}")]
        public async Task<FileDownloadModel> GetFileDownloadById(int id) => await CaffFileService.GetFileDownload(id);

        [HttpGet("{id/thumbnail}")]
        public async Task<FileDownloadModel> GetFileThumbnailById(int id) => await CaffFileService.GetFileThumbnail(id);

        [HttpPut("{id}")]
        public async Task ModifyFile(int id, FileModel modifiedFile) => await CaffFileService.ModifyFile(id, modifiedFile);

        [HttpDelete("{id}")]
        public async Task Remove(int id) => await CaffFileService.RemoveFileById(id);

        [Consumes("multipart/form-data")]
        [HttpPost]
        public async Task UploadFile([FromForm] NewFileModel newFile) => await CaffFileService.UploadFile(newFile);

    }
}
