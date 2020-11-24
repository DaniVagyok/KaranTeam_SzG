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
        public async Task<FileModel> GetFileById(int id) => await CaffFileService.GetFileById(id);

        [HttpPut("{id}")]
        public async Task ModifyFile(FileModel modifiedFile) => await CaffFileService.ModifyFile(modifiedFile);

        [HttpDelete("{id}")]
        public async Task Remove(int id) => await CaffFileService.RemoveFileById(id);

        // TODO: Change to form data
        [HttpPost]
        public async Task<NewFileModel> UploadFile(NewFileModel newFile) => await CaffFileService.UploadFile(newFile);

    }
}
