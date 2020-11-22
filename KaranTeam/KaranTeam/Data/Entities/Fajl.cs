using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Data.Entities
{
    public class Fajl
    {
        public int Id { get; set; }
        public string CAFFUri { get; set; }
        public string ThumbnailUri { get; set; }
        public string Cim { get; set; }
        public string Leiras { get; set; }
        public string LetrehozoId { get; set; }
        public Felhasznalo Letrehozo { get; set; }
        public IEnumerable<FajlKomment> FajlKommentek { get; set; }
    }
    public class FajlConfig : IEntityTypeConfiguration<Fajl>
    {
        public void Configure(EntityTypeBuilder<Fajl> builder)
        {
            builder.HasOne(f=> f.Letrehozo)
                   .WithMany(l => l.SajatFajlok)
                   .HasForeignKey(f => f.LetrehozoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(f => f.FajlKommentek)
                   .WithOne(fk => fk.Fajl)
                   .HasForeignKey(fk => fk.FajlId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
