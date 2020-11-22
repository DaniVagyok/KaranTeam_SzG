using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaranTeam.Data.Entities
{
    public class Felhasznalo : IdentityUser
    {
        public bool IsAdmin { get; set; } = false;
        public IEnumerable<Fajl> SajatFajlok { get; set; }
        public IEnumerable<FajlKomment> SajatFajlKommentek { get; set; }
    }

    public class FelhasznaloConfig : IEntityTypeConfiguration<Felhasznalo>
    {
        public void Configure(EntityTypeBuilder<Felhasznalo> builder)
        {
            builder.HasMany(f => f.SajatFajlok)
                   .WithOne(sf=> sf.Letrehozo)
                   .HasForeignKey(sf => sf.LetrehozoId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(f => f.SajatFajlKommentek)
                   .WithOne(sfk => sfk.Felhasznalo)
                   .HasForeignKey(sfk => sfk.FelhasznaloId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
