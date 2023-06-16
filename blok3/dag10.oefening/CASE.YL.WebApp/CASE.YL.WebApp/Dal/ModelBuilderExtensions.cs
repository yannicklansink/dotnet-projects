using CASE.YL.WebApp.Migrations;
using CASE.YL.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Dag8.oefening1.Dal
{
    public static class ModelBuilderExtensions
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cursus>().HasData(new Cursus
            {
                Id = 1,
                Duur = 4,
                Titel = "Programming C#",
                Code = "PROC#",
            },
            new Cursus
            {
                Id = 2,
                Duur = 2,
                Titel = "Programming C++",
                Code = "PROC++",
            },
            new Cursus
            {
                Id = 3,
                Duur = 5,
                Titel = "Programming Python",
                Code = "PROCPython",
            });

            modelBuilder.Entity<Cursist>().HasData(new Cursist
            {
                Id = 1,
                Voornaam = "Gert",
                Achternaam = "Jan",
            },
            new Cursist
            {
                Id = 2,
                Voornaam = "Pieter",
                Achternaam = "Bogard",
            },
            new Cursist
            {
                Id = 3,
                Voornaam = "Kelly",
                Achternaam = "Zuid",
            });

            modelBuilder.Entity<Cursusinstantie>().HasData(new Cursusinstantie
            {
                CususId = 1,
                CursistId = 1,
                Startdatum = new DateTime(2023, 9, 2),
            },
            new Cursusinstantie
            {
                CususId = 2,
                CursistId = 1,
                Startdatum = new DateTime(2023, 8, 12),
            },
            new Cursusinstantie
            {
                CususId = 3,
                CursistId = 2,
                Startdatum = new DateTime(2023, 11, 22),
            });
        }

    }
}
