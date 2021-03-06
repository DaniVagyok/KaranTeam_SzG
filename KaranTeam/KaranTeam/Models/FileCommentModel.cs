﻿using KaranTeam.Data.Entities;
using System;

namespace KaranTeam.Models
{
    public class FileCommentModel
    {
        public int Id { get; set; }
        public string OwnerName { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreationDate { get; set; }

		public FileCommentModel() { }
        public FileCommentModel(FileComment fileComment)
        {
            this.Id = fileComment.Id;
            this.OwnerName = fileComment.User.UserName;
            this.Content = fileComment.Content;
            this.CreationDate = fileComment.CreationDate;
        }

        public FileComment ToEntity(string userId)
		{
			return new FileComment
            {
                FileId = this.Id,
                UserId = userId,
                Content = this.Content,
                CreationDate = this.CreationDate
            };
		}
	}
}
