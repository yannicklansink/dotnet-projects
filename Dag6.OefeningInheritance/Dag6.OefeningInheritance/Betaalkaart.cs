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

        private decimal _saldo;
        //  Dat Saldo kan vervolgens alleen nog maar afnemen (minder worden). Het Saldo van een kaart moet kunnen worden opgevraagd.

        public Betaalkaart(string naam, decimal saldo)
        {
            Naam = naam;
            _saldo = saldo;
        }

        public abstract void Betaal(decimal bedrag);

        public decimal Saldo
        {
            get => _saldo;
            set
            { 
                if (_saldo > value)
                {
                    // geldig
                    _saldo = value;
                }
                else
                {
                    throw new SaldoOntoereikendException("Je mag geen saldo toevoegen.");
                }
            } 
        }

        public override string ToString()
        {
            return $"Het saldo van {Naam} is: {Saldo}";
        }


    }
}
