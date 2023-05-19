using cases.reisdocumenten.Controller;
using cases.reisdocumenten.DAL;
using cases.reisdocumenten.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace cases.reisdocumenten;
internal class Program
{
    static void Main(string[] args)
    {
        string connectionString = @"Server=localhost,1433;Database=ReisdocumentenDb2;User=SA;Password=kpHm4Cfc@;TrustServerCertificate=True";
        DbContextOptions<ReisdocumentenDbContext> options =
            new DbContextOptionsBuilder<ReisdocumentenDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        EnsureDatabase(options);
        LoadDataReisdocumenten(options);

        MainController controller = new MainController(options);
        controller.StartApp();
    }

    private static void EnsureDatabase(DbContextOptions<ReisdocumentenDbContext> options)
    {
        using (var context = new ReisdocumentenDbContext(options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
        Console.WriteLine("Your database has been created");
    }

    private static void LoadDataReisdocumenten(DbContextOptions<ReisdocumentenDbContext> options)
    {
        var burgers = new List<Burger>
        {
            new Burger { Bsn = 123456789, Voornaam = "John", Achternaam = "Doe", Tussenvoegsel = null, OorspronkelijkeNaam = "Doe", Straat = "Main Street", Huisnummer = 1, AchtervoegselHuisnummer = "A", Postcode = "12345", Plaats = "Hamelen", Geboorteplaats = "Hamelen", Geboorteland = "USA" },
            new Burger { Bsn = 234567890, Voornaam = "Jane", Achternaam = "Doe", Tussenvoegsel = null, OorspronkelijkeNaam = "Doe", Straat = "Oak Avenue", Huisnummer = 25, Postcode = "67890", Plaats = "Los Angeles", Geboorteplaats = "California", Geboorteland = "USA" },
            new Burger { Bsn = 345678901, Voornaam = "Robert", Achternaam = "Smith", Tussenvoegsel = null, OorspronkelijkeNaam = "Smith", Straat = "High Street", Huisnummer = 10, Postcode = "23456", Plaats = "London", Geboorteplaats = "London", Geboorteland = "GBR" },
            new Burger { Bsn = 456789012, Voornaam = "Emma", Achternaam = "Jones", Tussenvoegsel = null, OorspronkelijkeNaam = "Jones", Straat = "Park Lane", Huisnummer = 5, Postcode = "34567", Plaats = "Hamelen", Geboorteplaats = "Manchester", Geboorteland = "GBR" },
            new Burger { Bsn = 567890123, Voornaam = "Hans", Achternaam = "Müller", Tussenvoegsel = null, OorspronkelijkeNaam = "Müller", Straat = "Hauptstraße", Huisnummer = 20, AchtervoegselHuisnummer = "B", Postcode = "12345", Plaats = "Berlin", Geboorteplaats = "Berlin", Geboorteland = "DEU" },
            new Burger { Bsn = 678901234, Voornaam = "Maria", Achternaam = "García", Tussenvoegsel = null, OorspronkelijkeNaam = "García", Straat = "Calle Mayor", Huisnummer = 15, Postcode = "28001", Plaats = "Madrid", Geboorteplaats = "Madrid", Geboorteland = "ESP" }
        };

        var medewerkers = new List<Medewerker>()
        {
            new Medewerker { Naam = "Mieke", Afdeling = "Algemeen" },
            new Medewerker { Naam = "Arend", Afdeling = "Algemeen" },
            new Medewerker { Naam = "Els", Afdeling = "Reisdocumenten" },
            new Medewerker { Naam = "Mo", Afdeling = "Reisdocumenten" },
            new Medewerker { Naam = "Boris", Afdeling = "Algemeen" },
            new Medewerker { Naam = "Angela", Afdeling = "Informatievoorziening" }
        };

        // Set up the manager/subordinate relationships
        medewerkers.Single(m => m.Naam == "Arend").ManagerId = 1; // Arend is the top-level manager
        medewerkers.Single(m => m.Naam == "Mieke").ManagerId = null; // Mieke reports to Arend
        medewerkers.Single(m => m.Naam == "Els").ManagerId = 2; // Els reports to Arend
        medewerkers.Single(m => m.Naam == "Mo").ManagerId = 2; // Mo reports to Arend
        medewerkers.Single(m => m.Naam == "Boris").ManagerId = 2; // Boris reports to Arend
        medewerkers.Single(m => m.Naam == "Angela").ManagerId = 2; // Angela reports to Arend

        var soorten = new List<Soort>
        {
            new Soort { Naam = "paspoort", Prijs = 100.00m },
            new Soort { Naam = "id-kaart", Prijs = 55.25m },
            new Soort { Naam = "visum", Prijs = 400.50m },
        };

        var reisdocumenten = new List<Reisdocument>
        {

            new Reisdocument { DocumentNr = 123456, Soort = soorten[0], Aanvraagdatum = new DateTime(2024, 03, 20, 12, 30, 00), Afgifteplaats = "Hamelen", Afgiftedatum = new DateTime(2024, 04, 25), Verloopdatum = new DateTime(2023, 07, 25), Status = "Actief", Opgehaald = true, Burger = burgers.ElementAt(0), Medewerker = medewerkers.ElementAt(0)},
            new Reisdocument { DocumentNr = 234567, Soort = soorten.ElementAt(1), Aanvraagdatum = new DateTime(2023, 04, 22, 09, 45, 00), Afgifteplaats = "Den Haag", Afgiftedatum = new DateTime(2023, 04, 27), Verloopdatum = new DateTime(2024, 04, 27), Status = "verlopen", Opgehaald = false, Burger = burgers.ElementAt(1), Medewerker = medewerkers.ElementAt(1) },
            new Reisdocument { DocumentNr = 345678, Soort = soorten.ElementAt(2), Aanvraagdatum = new DateTime(2023, 04, 24, 11, 15, 00), Afgifteplaats = "Rotterdam", Afgiftedatum = new DateTime(2023, 04, 29), Verloopdatum = new DateTime(2024, 04, 29), Status = "Actief", Opgehaald = true, Burger = burgers.ElementAt(2), Medewerker = medewerkers.ElementAt(2) },
            new Reisdocument { DocumentNr = 456789, Soort = soorten.ElementAt(2), Aanvraagdatum = new DateTime(2024, 04, 26, 15, 00, 00), Afgifteplaats = "Utrecht", Afgiftedatum = new DateTime(2024, 05, 01), Verloopdatum = new DateTime(2023, 05, 01), Status = "Actief", Opgehaald = false, Burger = burgers.ElementAt(3), Medewerker = medewerkers.ElementAt(3) },
            new Reisdocument { DocumentNr = 567890, Soort = soorten.ElementAt(1), Aanvraagdatum = new DateTime(2023, 04, 28, 13, 30, 00), Afgifteplaats = "Amsterdam", Afgiftedatum = new DateTime(2023, 05, 03), Verloopdatum = new DateTime(2023, 06, 03), Status = "Actief", Opgehaald = true, Burger = burgers.ElementAt(4), Medewerker = medewerkers.ElementAt(4) },
            new Reisdocument { DocumentNr = 678901, Soort = soorten.ElementAt(0), Aanvraagdatum = new DateTime(2024, 04, 30, 10, 00, 00), Afgifteplaats = "Den Haag", Afgiftedatum = new DateTime(2024, 05, 05), Verloopdatum = new DateTime(2024, 05, 05), Status = "ingeleverd", Opgehaald = false, Burger = burgers.ElementAt(4), Medewerker = medewerkers.ElementAt(5) }
        };

        using (var context = new ReisdocumentenDbContext(options))
        {
            context.Burgers.Add(burgers.ElementAt(5));
            context.Reisdocumenten.AddRange(reisdocumenten);
            context.SaveChanges();
        }

    }


   

}
