using _11_5_23_repository.DAL;
using _11_5_23_repository.Model;
using Microsoft.EntityFrameworkCore;

namespace _11_5_23_repository
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "@Server=localhost,1433;Database=BlackJackDb;User=SA;Password=kpHm4Cfc@;TrustServerCertificate=true";

            DbContextOptions<BlackJackDbContext> options = new DbContextOptionsBuilder<BlackJackDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            using(var context = new BlackJackDbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            ISpelerRepository repo = new SpelerRepository(options);

            Speler speler = new Speler()
            {
                Naam = "Albert",
                Saldo = 20.35m,
                Tafel = new Tafel()
                {
                    Nummer = 1,
                    DealerNaam = "Pablo Escobar"
                },
            };
            
            repo.NieuweSpelerToevoegen(speler);
        }
    }
}