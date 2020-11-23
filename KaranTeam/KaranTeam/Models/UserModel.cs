using KaranTeam.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public bool IsAdmin { get; set; } = false;
        public string Name { get; set; }

        public UserModel() { }
        public UserModel(User user)
        {
            this.Id = user.Id;
            this.IsAdmin = user.IsAdmin;
            this.Name = user.Name;
        }

        public User ToEntity()
        {
            return new User
            {
                Id = this.Id,
                IsAdmin = this.IsAdmin,
                Name = this.Name
            };
        }
    }
}
