using KaranTeam.Data.Entities;
using KaranTeam.Models;
using KaranTeam.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KaranTeam.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/comment")]
    [ApiController]
    [Authorize]
    public class FileCommentController : ControllerBase
    {
        public IFileCommentService FileCommentService { get; }
        public FileCommentController(IFileCommentService service)
        {
            FileCommentService = service;
        }

        [HttpPut("{fileId}")]
        public async Task<FileComment> AddComment(int fileId, FileCommentModel model) => await FileCommentService.AddCommentByFileId(fileId, model.Content);

        [HttpDelete("{id}")]
        public async Task Remove(int id) => await FileCommentService.RemoveCommentById(id);
    }
}
