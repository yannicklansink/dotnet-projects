using _11_5_23_repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_5_23_repository.DAL
{
    public class SpelerRepository : ISpelerRepository
    {

        private readonly DbContextOptions<BlackJackDbContext> _options;

        public SpelerRepository(DbContextOptions<BlackJackDbContext> options)
        {
            // options zijn wachtwoord, gebruikersnaam, etc. Die geef je door aan de context
            _options = options;
        }

        public IEnumerable<Speler> GetAllSpelers()
        {
            throw new NotImplementedException();
        }

        public Speler GetSpelerById(long id)
        {
            throw new NotImplementedException();
        }

        public Speler GetSpelerByNaam(string naam)
        {
            throw new NotImplementedException();
        }

        public void NieuweSpelerToevoegen(Speler speler)
        {
            using (var context = new BlackJackDbContext(_options))
            {
                Tafel? tafel = context.Tafels.FirstOrDefault(t => t.Nummer == speler.Tafel.Nummer);
                if (tafel != null)
                {
                    speler.Tafel = tafel;
                }
                context.Spelers.Add(speler); // Expliciet aangeven dat het om de Spelers tabel gaat
                context.SaveChanges();
            }
        }

        public void SpelerSaldoAanpassen(Speler speler)
        {
            throw new NotImplementedException();
        }

        public void SpelerUitschrijven(Speler speler)
        {
            throw new NotImplementedException();
        }
    }
}
