
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

            modelBuilder.Entity<Particulier>().HasData(new Particulier
            {
                Id = 1,
                Voornaam = "Gert",
                Achternaam = "Jan",
                Straatnaam = "Spoorstraat",
                Huisnummer = 10,
                Postcode = "7573BZ",
                Woonplaats = "Bloemendaal",
                Rekeningnummer = "NL04ABNA4938384777",
            },
            new Particulier
            {
                Id = 2,
                Voornaam = "Pieter",
                Achternaam = "Bogard",
            },
            new Particulier
            {
                Id = 3,
                Voornaam = "Kelly",
                Achternaam = "Zuid",
            });

            modelBuilder.Entity<Bedrijfsmedewerker>().HasData(new Bedrijfsmedewerker
            {
                Id = 4,
                Voornaam = "Gerard",
                Achternaam = "Stevens",
                Bedrijfsnaam = "Amazon",
                Afdeling = "Inkoop",
                Offertenummer = 12345678,
            },
            new Bedrijfsmedewerker
            {
                Id = 5,
                Voornaam = "Josoef",
                Achternaam = "Kentelier",
                Bedrijfsnaam = "Juwelier Vreriks",
                Afdeling = "Goudsmith",
                Offertenummer = 48375198,
            },
            new Bedrijfsmedewerker
            {
                Id = 6,
                Voornaam = "Samuel",
                Achternaam = "Truida",
                Bedrijfsnaam = "Apple",
                Afdeling = "Inkoop",
                Offertenummer = 47293343,
            });

            modelBuilder.Entity<Cursusinstantie>().HasData(new Cursusinstantie
            {
                CursusId = 1,
                CursistId = 1,
                Startdatum = new DateTime(2023, 9, 2),
            },
            new Cursusinstantie
            {
                CursusId = 2,
                CursistId = 1,
                Startdatum = new DateTime(2023, 8, 12),
            },
            new Cursusinstantie
            {
                CursusId = 2,
                CursistId = 4,
                Startdatum = new DateTime(2023, 8, 12),
            },
            new Cursusinstantie
            {
                CursusId = 2,
                CursistId = 5,
                Startdatum = new DateTime(2023, 8, 12),
            },
            new Cursusinstantie
            {
                CursusId = 2,
                CursistId = 6,
                Startdatum = new DateTime(2023, 8, 12),
            },
            new Cursusinstantie
            {
                CursusId = 3,
                CursistId = 2,
                Startdatum = new DateTime(2023, 11, 22),
            });




        }

    }
}
