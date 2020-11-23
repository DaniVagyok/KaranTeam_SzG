using KaranTeam.Data.Entities;
using KaranTeam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Services
{
    interface IFileCommentService
    {
        public Task<IEnumerable<FileCommentModel>> GetCommentsByFileId(int fileId);
        public Task<FileComment> AddCommentByFileId(int fileId, string commentContent);
        public Task RemoveCommentById(int commentId);
    }
}
