using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Deck
    {

        // Deck has a list of 52 cards
        public List<Card> CardList { get; set; }
        public const int DeckSize = 52;

        public Deck()
        {
            CardList = new List<Card>();
            GenerateDeck();
        }

        private void GenerateDeck()
        {
            // 13 ranks
            // 4 suits
            for (int i = 0; i < 52; i++)
            {
                Rank rank = (Rank)(i % 13);
                Suit suit = (Suit)(i % 4);
                CardList.Add(new Card(rank, suit));
            }
        }

       
    }
}
