using KaranTeam.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Models
{
    public class UserDetailsModel
    {
		public string Id { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public bool IsAdmin { get; set; }

		public UserDetailsModel() { }
		public UserDetailsModel(User user)
		{
			this.Id = user.Id;
			this.Email = user.Email;
			this.UserName = user.UserName;
			this.IsAdmin = user.IsAdmin;
		}

		public User ToEntity()
		{
			return new User
			{
				Id = this.Id,
				Email = this.Email,
				UserName = this.UserName,
				IsAdmin = this.IsAdmin
			};
		}
	}
}
