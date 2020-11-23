using KaranTeam.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Models
{
    public class FileListModel
    {
        public int Id { get; set; }
        public string ThumbnailUri { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string OwnerName { get; set; }
        public int CommentCount { get; set; }

		public FileListModel(File file)
		{
			this.Id = file.Id;
			this.ThumbnailUri = file.ThumbnailUri;
			this.Title = file.Title;
			this.Description = file.Description;
			this.OwnerName = file.Owner.Name;
			this.CommentCount = file.FileComments.Count();
		}
	}
}
