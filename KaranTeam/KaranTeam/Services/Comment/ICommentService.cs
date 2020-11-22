using KaranTeam.Data.Entities;
using KaranTeam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Services
{
    interface ICommentService
    {
        public Task<IEnumerable<FileCommentModel>> GetCommentsByFileId(int fileId);
        public FileComment AddCommentByFileId(int fileId, string commentContent);
        public void RemoveCommentById(int commentId);
    }
}
