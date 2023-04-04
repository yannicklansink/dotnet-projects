using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Dealer : IMoves
    {

        public Dealer(Game game, string name = "Dealer") : base(game, name)
        {

        }

        public List<Card> GetCards()
        {
            return Hand.CardList;
        }


        public void Play()
        {
            // start when Player IsStand == true
            // maybe make an eventlistener for Player IsStand field?
            // Dealer player untill Hand total value is >= 17 or bust
            while (!IsBust() && Hand.GetTotalValue() < 17)
            {
                // keep playing!
                Hit(); // Hit() will already print a bust message.

            }
            // stop playing
        }

    }
}
