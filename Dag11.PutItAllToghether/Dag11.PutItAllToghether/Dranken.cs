using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag11.PutItAllToghether
{
    public struct Dranken
    {
        public string DrankNaam { get; set ; }

        public string DrankBeschrijving { get; set; }
        public decimal Bedrag { get; set; }
        public decimal BedragExtra { get; set; }

        public decimal TotaalBedrag
        {
            get
            {
                return Bedrag + BedragExtra; 
            }
        }

        public Dranken(string drankNaam, decimal bedrag, decimal bedragExtra = 0m, string drankBeschrijving = null)
        {
            DrankNaam = drankNaam;
            Bedrag = bedrag;
            BedragExtra = bedragExtra;
            DrankBeschrijving = drankBeschrijving; 
        }

        public override string ToString()
        {
            bool IsDrankBeschrijving = !string.IsNullOrEmpty(DrankBeschrijving);
            //                                                                                                   hoezo werkt dit niet?
            return $"Drankje: {DrankNaam}, Totaal bedrag: {TotaalBedrag} {(IsDrankBeschrijving ? ", Beschrijving: {DrankBeschrijving}" : "")}";
        }





    }
}
