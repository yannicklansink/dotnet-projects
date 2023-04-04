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
        public const int DeckSize = 312; // put it on 312 no 52? (52*6=312). Puts all 6 decks inside one list.


        public Deck()
        {
            CardList = new List<Card>();
            GenerateDeck();
        }

        private void GenerateDeck()
        {
            // 13 ranks
            // 4 suits
            for (int i = 0; i < DeckSize; i++)
            {
                Rank rank = (Rank)(i % 13);
                Suit suit = (Suit)(i % 4);
                CardList.Add(new Card(rank, suit));
            }
        }

        public void Shuffle()
        {
            Random rand = new Random();
            var shuffled = CardList.OrderBy(x => rand.Next()).ToList();
            CardList.Clear();
            CardList.AddRange(shuffled);
        }

        // draw last card in list. Better for performance?   
        public Card Draw()
        {
            // Check if CardList is empthy? 
            return 
        }

        public bool IsCardListEmpthy()
        {
            //return CardList.Count == 0 ? true : false; 
            // this is not correct, throw an exception when card list is empthy and tell user.

        }


    }
}
