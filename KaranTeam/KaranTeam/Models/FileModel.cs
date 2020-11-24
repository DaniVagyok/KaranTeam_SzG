using KaranTeam.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Models
{
	public class FileModel
	{
		public int Id { get; set; }
		public string ThumbnailUri { get; set; }
		public string CAFFUri { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string OwnerName { get; set; }
		public IEnumerable<FileCommentModel> FileComments { get; set; }

		public FileModel() { }
		public FileModel(CaffFile file)
		{
			this.Id = file.Id;
			this.ThumbnailUri = file.ThumbnailUri;
			this.CAFFUri = file.CAFFUri;
			this.Title = file.Title;
			this.Description = file.Description;
			this.OwnerName = file.Owner.UserName;
			this.FileComments = file.FileComments
				.Select(fc => new FileCommentModel(fc))
				.ToList();
		}

		public CaffFile ToEntity(string userId)
        {
			return new CaffFile
			{
				Id = this.Id,
				ThumbnailUri = this.ThumbnailUri,
				CAFFUri = this.CAFFUri,
				Title = this.Title,
				Description = this.Description,
				FileComments = this.FileComments.Select(fc => fc.ToEntity(userId))
			};
		}
	}
}
