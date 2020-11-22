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
        public void AddCommentByFileId(string fileId, FileCommentModel newComment);
    }
}
