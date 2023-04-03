using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Card
    {

        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        public int Value
        {
            get
            {
                return (int)Rank;
            }
        }

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }



    }
}
