using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_5_23_repository.Model
{
    public interface ISpelerRepository
    {
        IEnumerable<Speler> GetAllSpelers();

        Speler GetSpelerById(long id);

        Speler GetSpelerByNaam(String naam);

        void NieuweSpelerToevoegen(Speler speler);

        void SpelerUitschrijven(Speler speler);

        void SpelerSaldoAanpassen(Speler speler);


    }
}
