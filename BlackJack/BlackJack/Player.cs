using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Player : IMoves
    {

        private decimal _saldo;
        private decimal _bet;
        public bool IsStand { get; set; }
        

        public Player(Game game, decimal bet = 1m, string name = "Player", Decimal saldo = 20m) : base(game, name)
        {
            _saldo = saldo;
            _bet = bet;
            IsStand = false;

        }

        public decimal Saldo
        {
            get { return _saldo; }
            private set { _saldo = value; }
        }

        public void Stand()
        {
            // skip.
            // dealer moet kaart omdraaien. -> dealer moet hit aanroepen totdat 
            IsStand = true;
            Game.Dealer.Play();
        }


    }
}
