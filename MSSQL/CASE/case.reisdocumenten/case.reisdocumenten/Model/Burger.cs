using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cases.reisdocumenten.Model
{
    public class Burger
    {
        public int Id { get; set; }

    
        public int Bsn { get; set; }

        public string Voornaam { get; set; }

        public string Achternaam { get; set; }

        public string Tussenvoegsel { get; set; }

        public string OorspronkelijkeNaam { get; set; }

        public string Straat { get; set; }

        public int Huisnummer { get; set; }

        public string AchtervoegselHuisnummer { get; set; }

        public string Postcode { get; set; }

        public string Plaats { get; set; }

        public string Geboorteplaats { get; set; }

        public string Geboorteland { get; set; }

        public List<Reisdocument> Reisdocumenten { get; set; }
    }
}
