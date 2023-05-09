using _9_5_23.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_5_23
{
    internal class MuziekDbContext : DbContext
    {
        // geef hier aan welke entiteiten je op wilt querien.
        public DbSet<Nummer> Nummer { get; set; }

        public DbSet<Album> Album { get; set; }

        public DbSet<Artiest> Artiest { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionstring =
                @"Server=localhost,1433;Database=MuziekDB;User=SA;Password=kpHm4Cfc@;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connectionstring);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nummer>(nummer =>
            {
                // non-clustered index ligt op de namen van de nummers
                nummer.HasIndex(e => e.Naam).IsClustered(false);
               

                nummer.ToTable("muzieknummer", "muziek");
                nummer.Property(n => n.Naam).HasMaxLength(128);
            });

            modelBuilder.Entity<Album>(album =>
            {
                album.ToTable("album", "muziek");
                album.Property(a => a.Naam).HasMaxLength(256);
            });

            modelBuilder.Entity<Artiest>(artiest =>
            {
                artiest.ToTable("artiest", "muziek");
                artiest.Property(a => a.Naam).HasMaxLength(100);
            });
        }
    }
}
