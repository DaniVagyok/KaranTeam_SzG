using KaranTeam.Data;
using KaranTeam.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Services.Comment
{
    public class CommentService: ICommentService
    {
        private ApplicationDbContext Context { get; }

        public CommentService(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<FileCommentModel>> GetCommentsByFileId(string fileId)
        {
            return await Context.FileComments
                .Where(fc => fc.FileId.Equals(fileId))
                .Select(fc => new FileCommentModel
                {
                    Id = fc.Id,
                    OwnerName = fc.User.Name,
                    Content = fc.Content,
                    CreationDate = fc.CreationDate
                }).ToListAsync();      
        }
    }
}
