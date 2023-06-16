using CASE.YL.WebApp.Models;
using Dag8.oefening1.Dal;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CASE.YL.WebApp.Dal
{
    public class CursusContext : DbContext // change to: IdentityDbContext<Gebruiker>
    {

        private readonly IConfiguration _config;

        public DbSet<Cursus> Cursussen { get; set; }

        public DbSet<Cursist> Custisten { get; set; }

        public DbSet<Cursusinstantie> Cursusinstanties { get; set; }

        public CursusContext(DbContextOptions<CursusContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder); // keys of Identity tables are mapped in OnModelCreating
            
            modelBuilder.Entity<Cursusinstantie>()
               .HasKey(c => new { c.CususId, c.CursistId });

            modelBuilder.Entity<Cursusinstantie>()
                .HasOne(ci => ci.Cursus)
                .WithMany(c => c.Cursusinstanties)
                .HasForeignKey(ci => ci.CususId);

            modelBuilder.Entity<Cursusinstantie>()
                .HasOne(ci => ci.Cursist)
                .WithMany(c => c.Cursusinstanties)
                .HasForeignKey(ci => ci.CursistId);

            modelBuilder.Seed();
        }

    }
}
