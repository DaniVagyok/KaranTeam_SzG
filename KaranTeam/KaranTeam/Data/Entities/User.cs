using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Data.Entities
{
    public class User : IdentityUser
    {
        public bool IsAdmin { get; set; } = false;
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<File> Files { get; set; }
        public IEnumerable<FileComment> FileComments { get; set; }
    }

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(f => f.Files)
                   .WithOne(sf=> sf.Owner)
                   .HasForeignKey(sf => sf.OwnerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(f => f.FileComments)
                   .WithOne(sfk => sfk.User)
                   .HasForeignKey(sfk => sfk.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
