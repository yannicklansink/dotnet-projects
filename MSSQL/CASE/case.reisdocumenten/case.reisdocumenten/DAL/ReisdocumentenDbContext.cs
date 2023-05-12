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

        public DbSet<Medewerker> Medewerkers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Burger>(entity =>
            {
                entity.ToTable("Burgers");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Bsn)
                    .HasColumnName("BSN")
                    .IsRequired();

                entity.Property(e => e.Voornaam)
                    .HasColumnName("voornaam")
                    .HasMaxLength(65)
                    .IsRequired();

                entity.Property(e => e.Achternaam)
                    .HasColumnName("achternaam")
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.Tussenvoegsel)
                    .HasColumnName("tussenvoegsel")
                    .HasMaxLength(20);

                entity.Property(e => e.OorspronkelijkeNaam)
                    .HasColumnName("oorspronkelijke_naam")
                    .HasMaxLength(65)
                    .IsRequired();

                entity.Property(e => e.Straat)
                     .HasColumnName("straat")
                     .HasMaxLength(50)
                     .IsRequired();

                entity.Property(e => e.Huisnummer)
                    .HasColumnName("huisnummer")
                    .IsRequired();

                entity.Property(e => e.AchtervoegselHuisnummer)
                    .HasColumnName("achtervoegsel_huisnummer")
                    .HasMaxLength(5);

                entity.Property(e => e.Postcode)
                    .HasColumnName("postcode")
                    .HasMaxLength(5)
                    .IsRequired();

                entity.Property(e => e.Plaats)
                    .HasColumnName("plaats")
                    .HasMaxLength(58)
                    .IsRequired();

                entity.Property(e => e.Geboorteplaats)
                    .HasColumnName("geboorteplaats")
                    .HasMaxLength(58)
                    .IsRequired();

                entity.Property(e => e.Geboorteland)
                    .HasColumnName("geboorteland")
                    .HasMaxLength(3)
                    .IsRequired();

            });

            modelBuilder.Entity<Soort>(entity =>
            {
                entity.ToTable("Soorten");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Naam)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.Prijs)
                    .IsRequired()
                    .HasColumnType("decimal(6,2)");

                
            });

            modelBuilder.Entity<Reisdocument>(entity =>
            {
                entity.ToTable("Reisdocumenten");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Aanvraagdatum)
                   .IsRequired();

                entity.Property(e => e.Afgifteplaats)
                    .IsRequired()
                    .HasDefaultValue("Hamelen");

                entity.Property(e => e.Status)
                    .IsRequired();

                entity.Property(e => e.Opgehaald)
                    .IsRequired()
                    .HasDefaultValue(false);

                entity.HasOne(e => e.Burger)
                    .WithMany(b => b.Reisdocumenten)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Reisdocumenten_Burgers");


                entity.HasOne(e => e.Soort)
                    .WithMany(s => s.Reisdocumenten)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_reisdocumenten_soorten");

            });

            modelBuilder.Entity<Medewerker>(entity =>
            {
                //entity.ToTable("Medewerkers");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Naam)
                    .IsRequired();

                entity.Property(e => e.ManagerId)
                    .IsRequired(false);

                modelBuilder.Entity<Medewerker>()
                    .HasOne(m => m.Manager)
                    .WithMany()
                    .HasForeignKey(m => m.ManagerId)
                    // Entity Framework does not allow multiple cascade paths by default
                    // The default is no action
                    // When a parent is deleted there will be a DbUpdateException thrown if it has any childeren.
                    .OnDelete(DeleteBehavior.Restrict);


            });
        }
    }
}
