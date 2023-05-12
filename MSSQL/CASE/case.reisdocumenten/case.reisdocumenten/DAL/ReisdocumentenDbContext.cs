using cases.reisdocumenten.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cases.reisdocumenten.DAL
{
    public class ReisdocumentenDbContext : DbContext
    {

        public ReisdocumentenDbContext(DbContextOptions<ReisdocumentenDbContext> options)
            : base(options)
        {
        }

        public DbSet<Burger> Burgers { get; set; }
        public DbSet<Reisdocument> Reisdocumenten { get; set; }
        public DbSet<Soort> Soorten { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Burger>(entity =>
            {
                entity.ToTable("Burgers");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Bsn)
                    .IsRequired();

                entity.Property(e => e.Voornaam)
                    .IsRequired();

                entity.Property(e => e.Achternaam)
                    .IsRequired();

                entity.Property(e => e.OorspronkelijkeNaam)
                    .IsRequired();

                entity.Property(e => e.Straat)
                    .IsRequired();

                entity.Property(e => e.Huisnummer)
                    .IsRequired();

                entity.Property(e => e.Postcode)
                    .IsRequired();

                entity.Property(e => e.Plaats)
                    .IsRequired();

                entity.Property(e => e.Geboorteplaats)
                    .IsRequired();

                entity.Property(e => e.Geboorteland)
                    .IsRequired();

                
            });

            modelBuilder.Entity<Soort>(entity =>
            {
                entity.ToTable("Soorten");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Naam)
                    .IsRequired();

                entity.Property(e => e.Prijs)
                    .IsRequired()
                    .HasColumnType("decimal(6,2)");

                
            });

            modelBuilder.Entity<Reisdocument>(entity =>
            {
                entity.ToTable("Reisdocumenten");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.DocumentNr);

                entity.Property(e => e.Aanvraagdatum)
                    .IsRequired();

                entity.Property(e => e.Afgifteplaats)
                    .IsRequired()
                    .HasDefaultValue("Hamelen");

                entity.Property(e => e.Afgiftedatum);

                entity.Property(e => e.Verloopdatum);

                entity.Property(e => e.Status)
                    .IsRequired();

                entity.Property(e => e.Opgehaald)
                    .IsRequired()
                    .HasDefaultValue(false);
               
            });
        }
    }
}
