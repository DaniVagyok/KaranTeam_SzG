using KaranTeam.Data.Entities;
using KaranTeam.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaranTeam.Services
{
    public interface IFileCommentService
    {
        Task<IEnumerable<FileCommentModel>> GetCommentsByFileId(int fileId);
        Task<FileComment> AddCommentByFileId(int fileId, string commentContent);
        Task RemoveCommentById(int commentId);
    }
}
