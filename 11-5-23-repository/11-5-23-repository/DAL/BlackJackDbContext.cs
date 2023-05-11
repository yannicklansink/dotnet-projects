using _11_5_23_repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_5_23_repository.DAL
{
    public class BlackJackDbContext : DbContext
    {
        public DbSet<Speler> Spelers { get; set; }

        public DbSet<Tafel> Tafels { get; set; }

        public BlackJackDbContext(DbContextOptions<BlackJackDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speler>()
                .Property(sp => sp.Naam).HasMaxLength(75);
            modelBuilder.Entity<Speler>()
                .HasIndex(sp => sp.Naam).IsClustered().IsUnique();

            modelBuilder.Entity<Tafel>()
               .Property(tf => tf.DealerNaam).HasMaxLength(75);
        }

        // Gaan we niet meer doen, want password hardcode is niet slim!
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        */



    }
}
