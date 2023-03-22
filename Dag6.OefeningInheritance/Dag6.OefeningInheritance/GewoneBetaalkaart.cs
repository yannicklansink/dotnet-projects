using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag6.OefeningInheritance
{
    public class GewoneBetaalkaart : Betaalkaart
    {
        public GewoneBetaalkaart(string naam, decimal saldo) : base(naam, saldo)
        {


        }

        public void Betaal(decimal bedrag)
        {
            //  Bij gewone betaalkaarten mag je nooit méér betalen dat dat er nog aan Saldo aanwezig is
            if ((Saldo - bedrag) > 0.00m) // saldo = 10.00 bedrag = 11.00
            {
                base.Saldo = Saldo - bedrag;
            } else
            {
                throw new SaldoOntoereikendException($"Uw saldo van {base.Saldo} Euro is ontoereikend om een bedrag van {bedrag} mee te betalen");
            }
        }

     
    }
}
