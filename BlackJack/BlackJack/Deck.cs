using BlackJack.Exceptions;
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
            // 13 ranks // 4 suits
            for (int i = 0; i < DeckSize; i++)
            {
                Rank rank = (Rank)(i % 13);
                Suit suit = (Suit)(i % 4);
                CardList.Add(new Card(rank, suit));
            }
        }

        public void Shuffle()
        {
            Random random = new Random();

            // the lambda expression x => random.Next() generates
            // a random number for each element in the list
            // and sorts the list based on these random numbers. 
            var shuffled = CardList.OrderBy(x => random.Next()).ToList();
            CardList = shuffled;
        }

        public Card Draw()
        {
            IsCardListEmpty();
            Card card = CardList.Last();
            CardList.RemoveAt(CardList.Count - 1);
            return card;
        }

        private bool IsCardListEmpty()
        {
            return CardList.Count == 0 ? throw new CardListEmptyException("The card list is empty. You have played to much.") : false;
        }



    }
}
