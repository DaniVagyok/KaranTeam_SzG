using KaranTeam.Data;
using KaranTeam.Data.Entities;
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
        private IUserManager UserManager { get; }
        private ApplicationDbContext Context { get; }

        public CommentService(ApplicationDbContext context,
            IUserManager userManager)
        {
            UserManager = userManager;
            Context = context;
        }

        public async Task<IEnumerable<FileCommentModel>> GetCommentsByFileId(string fileId)
        {
            return await Context.FileComments
                .Where(fc => fc.FileId.Equals(fileId))
                .Select(fc => new FileCommentModel
                {
                    Id = fc.Id,
                    FileId = fc.FileId,
                    OwnerName = fc.User.Name,
                    Content = fc.Content,
                    CreationDate = fc.CreationDate
                }).ToListAsync();      
        }

        public void AddComment(FileCommentModel newComment)
        {
            FileComment newCommentEntity = new FileComment
            {
                   FileId = newComment.FileId,
                   UserId = UserManager.GetFelhasznaloId(),
                   Content = newComment.Content,
                   CreationDate = newComment.CreationDate

            };

            Context.FileComments.Add(newCommentEntity);
        }
    }
}
