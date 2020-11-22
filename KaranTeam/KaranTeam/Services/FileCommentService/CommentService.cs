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

        public async Task<IEnumerable<FileCommentModel>> GetCommentsByFileId(int fileId)
        {
            return await Context.FileComments
                .Where(fc => fc.FileId == fileId)
                .Select(fc => new FileCommentModel
                {
                    Id = fc.Id,
                    OwnerName = fc.User.Name,
                    Content = fc.Content,
                    CreationDate = fc.CreationDate
                }).ToListAsync();      
        }

        public FileComment AddCommentByFileId(int fileId, string commentContent)
        {
            var newEntity = new FileComment
            {
                   FileId = fileId,
                   UserId = UserManager.GetUserId(),
                   Content = commentContent,
                   CreationDate = new DateTime()

            };
            var result = Context.FileComments.Add(newEntity);
            return result.Entity;
        }

        public void RemoveCommentById(int commentId)
        {
            var removableEntity = Context.FileComments.Find(commentId);
            Context.FileComments.Remove(removableEntity);
        }
    }
}
