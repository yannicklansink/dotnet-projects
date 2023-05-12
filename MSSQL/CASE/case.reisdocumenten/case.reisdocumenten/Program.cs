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
        LoadDataSoort(options);
        LoadDataMedewerker(options);
    }

    private static void LoadDataMedewerker(DbContextOptions<ReisdocumentenDbContext> options)
    {
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

        using (var context = new ReisdocumentenDbContext(options))
        {
            context.Medewerkers.AddRange(medewerkers);
            context.SaveChanges();
        }

        
    }

    private static void LoadDataSoort(DbContextOptions<ReisdocumentenDbContext> options)
    {
        var soorten = new List<Soort>
        {
            new Soort { Naam = "paspoort", Prijs = 100.00m },
            new Soort { Naam = "id-kaart", Prijs = 55.25m },
            new Soort { Naam = "visum", Prijs = 400.50m },
        };

        using (var context = new ReisdocumentenDbContext(options))
        {
            context.AddRange(soorten);
            context.SaveChanges();
        }

        
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
}
