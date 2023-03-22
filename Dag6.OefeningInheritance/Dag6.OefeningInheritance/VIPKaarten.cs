using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag6.OefeningInheritance
{
    public class VIPKaarten : Betaalkaart
    {

        protected int KortingsPercentage;

        public VIPKaarten(string naam, decimal saldo, int kortingspercentage = 10) : base(naam, saldo)
        {
            KortingsPercentage = kortingspercentage;

        }

        public void Betaal(decimal bedrag)
        {
            // Bij VIPkaarten mag je wèl meer betalen dan dat er saldo aanwezig is.
            // Bovendien worden VIPkaarten aangemaakt met een kortingspercentage (standaard 10%).
            // Bij elk bedrag dat betaald wordt, wordt eerst de korting verrekend voordat het bedrag van het saldo afgehaald wordt.
            decimal BedragTeBetalenMetKorting = bedrag - ((bedrag / 100) * KortingsPercentage);
            base.Saldo = Saldo - BedragTeBetalenMetKorting;

        }


    }
}
