using KaranTeam.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Models
{
	public class FileDetailsModel
	{
		public int Id { get; set; }
		public string ThumbnailUri { get; set; }
		public string CAFFUri { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public UserModel Owner { get; set; }
		public IEnumerable<FileCommentModel> FileComments { get; set; }

		public FileDetailsModel() { }
		public FileDetailsModel(File file)
		{
			this.Id = file.Id;
			this.ThumbnailUri = file.ThumbnailUri;
			this.CAFFUri = file.CAFFUri;
			this.Title = file.Title;
			this.Description = file.Description;
			this.Owner = new UserModel(file.Owner);
			this.FileComments = file.FileComments
				.Select(fc => new FileCommentModel(fc))
				.ToList();
		}

		public File ToEntity()
        {
			return new File
			{
				Id = this.Id,
				ThumbnailUri = this.ThumbnailUri,
				CAFFUri = this.CAFFUri,
				Title = this.Title,
				Description = this.Description

			};
		}
	}
}
