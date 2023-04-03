using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Game
    {

        // 1 game has 6 decks. 1 deck has 52 cards
        public List<Deck> DeckList;
        private const int NumberOfDecks = 6;

        public Game()
        {
            DeckList = new List<Deck>();

        }
    }
}
