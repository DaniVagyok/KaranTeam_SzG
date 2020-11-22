using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int FileId { get; set; }
        public File File { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
    }
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(fk=> fk.User)
                   .WithMany(f=>f.Comments)
                   .HasForeignKey(fk=>fk.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(fk => fk.File)
                   .WithMany(f => f.FajlKommentek)
                   .HasForeignKey(fk => fk.FileId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
