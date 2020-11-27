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
    public class FileCommentService: IFileCommentService
    {
        private ILoggedInUser UserManager { get; }
        private ApplicationDbContext Context { get; }

        public FileCommentService(ApplicationDbContext context,
            ILoggedInUser userManager)
        {
            UserManager = userManager;
            Context = context;
        }

        public async Task<IEnumerable<FileCommentModel>> GetCommentsByFileId(int fileId)
        {
            return await Context.FileComments
                .Where(fc => fc.FileId == fileId)
                .Select(fc => new FileCommentModel(fc))
                .ToListAsync();      
        }

        public async Task<FileComment> AddCommentByFileId(int fileId, string commentContent)
        {
            var newEntity = new FileComment
            {
                   FileId = fileId,
                   UserId = UserManager.GetUserId(),
                   Content = commentContent,
                   CreationDate = DateTimeOffset.Now

            };
            var result = Context.FileComments.Add(newEntity);
            await Context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task RemoveCommentById(int commentId)
        {
            var user = await Context.Users.Where(u => u.Id == UserManager.GetUserId()).SingleOrDefaultAsync();
            if (user.IsAdmin)
            {
                var removableEntity = Context.FileComments.Find(commentId);
                Context.FileComments.Remove(removableEntity);
                await Context.SaveChangesAsync();
            }
        }
    }
}
