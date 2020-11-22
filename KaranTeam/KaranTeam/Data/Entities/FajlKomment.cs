using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Data.Entities
{
    public class FajlKomment
    {
        public int Id { get; set; }
        public int FajlId { get; set; }
        public Fajl Fajl { get; set; }
        public string FelhasznaloId { get; set; }
        public Felhasznalo Felhasznalo { get; set; }
        public string Komment { get; set; }
    }
    public class FajlKommentConfig : IEntityTypeConfiguration<FajlKomment>
    {
        public void Configure(EntityTypeBuilder<FajlKomment> builder)
        {
            builder.HasOne(fk=> fk.Felhasznalo)
                   .WithMany(f=>f.SajatFajlKommentek)
                   .HasForeignKey(fk=>fk.FelhasznaloId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(fk => fk.Fajl)
                   .WithMany(f => f.FajlKommentek)
                   .HasForeignKey(fk => fk.FajlId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
