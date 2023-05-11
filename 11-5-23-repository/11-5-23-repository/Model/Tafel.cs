using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_5_23_repository.Model
{
    public class Tafel
    {
        public int Id { get; set; }

        public int Nummer { get; set; }

        public string DealerNaam { get; set; }

        // navigation propertie. Zodat de prop in de afgeleide class overschreven kan worden. 
        public virtual List<Speler> Spelers { get; set; }
    }
}
