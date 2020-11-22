using KaranTeam.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaranTeam.Data.Entities;

namespace KaranTeam.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<User>
    {
        public DbSet<File> Fajlok { get; set; }
        public DbSet<FileComment> FajlKommentek { get; set; }
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FileConfig());
            modelBuilder.ApplyConfiguration(new FileCommentConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }
    }
}
