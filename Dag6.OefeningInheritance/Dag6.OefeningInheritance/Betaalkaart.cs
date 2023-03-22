using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag6.OefeningInheritance
{
    public abstract class Betaalkaart
    {

        protected string Naam;
        protected decimal Saldo;
        //  Dat Saldo kan vervolgens alleen nog maar afnemen (minder worden). Het Saldo van een kaart moet kunnen worden opgevraagd.

        public Betaalkaart(string naam, decimal saldo)
        {
            Naam = naam;
            Saldo = saldo;
        }

        


    }
}
