using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cases.reisdocumenten.Model
{
    public class Medewerker
    {
        public int Id { get; set; }

        public string Naam { get; set; }

        public string? Straat { get; set; }

        public int? Huisnummer { get; set; }

        public string? Postcode { get; set; }

        public string? Woonplaats { get; set; }

        public int? ManagerId { get; set; }

        public Medewerker Manager { get; set; }

        // afdeling: Reisdocumenten, Reisdocumenten, Informatievoorziening
        public string Afdeling { get; set; }
    }
}
