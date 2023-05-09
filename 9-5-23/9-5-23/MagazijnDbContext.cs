using _9_5_23.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_5_23
{
    internal class MagazijnDbContext : DbContext
    {
        // geef hier aan welke entiteiten je op wilt querien.
        public DbSet<Voorraad> Voorraad { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionstring =
                @"Server=localhost,1433;Database=MagazijnDB;User=SA;Password=kpHm4Cfc@;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connectionstring);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Voorraad>(locatie =>
            {
                locatie.ToTable("voorraad", "ikea");
                locatie.Property(l => l.Artikel).HasMaxLength(100);
            });
        }
    }
}
