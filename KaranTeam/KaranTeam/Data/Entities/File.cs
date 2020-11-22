using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Data.Entities
{
    public class File
    {
        public int Id { get; set; }
        public string CAFFUri { get; set; }
        public string ThumbnailUri { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string OwnerId { get; set; }
        public User Owner { get; set; }
        public IEnumerable<Comment> FajlKommentek { get; set; }
    }
    public class FileConfig : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.HasOne(f=> f.Owner)
                   .WithMany(l => l.Files)
                   .HasForeignKey(f => f.OwnerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(f => f.FajlKommentek)
                   .WithOne(fk => fk.File)
                   .HasForeignKey(fk => fk.FileId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
