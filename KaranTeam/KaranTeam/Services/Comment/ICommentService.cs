using KaranTeam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Services
{
    interface ICommentService
    {
        public Task<IEnumerable<FileCommentModel>> GetCommentsByFileId(string fileId);
        public void AddCommentByFileId(int fileId, FileCommentModel newComment);
        public void RemoveCommentById(int commentId);
    }
}
