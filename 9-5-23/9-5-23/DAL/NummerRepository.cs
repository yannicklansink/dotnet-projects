using _9_5_23.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_5_23.DAL
{
    public class NummerRepository : INummerRepository
    {
        public IEnumerable<Nummer> GetAllNummers()
        {
            
        }

        public void VoegNummerToe(Nummer nummer)
        {
            using (var context = new MuziekDbContext())
            {
                Nummer? nummers = context.Nummer.FirstOrDefault(t => t.Nummer == nummers.Num.Nummer);
                if (nummers != null)
                {
                    speler.Tafel = nummers;
                }
                context.Spelers.Add(speler); // Expliciet aangeven dat het om de Spelers tabel gaat
                context.SaveChanges();
            }
        }

        public void WijzigNummerLengte(Nummer nummer)
        {
            throw new NotImplementedException();
        }
    }
}
