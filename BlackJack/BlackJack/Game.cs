using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Game
    {

        private const int NumberOfDecks = 6;
        public Deck Deck;
        public Player Player { get; set; }
        public Dealer Dealer { get; set; }

        public Game()
        {
            Deck = new Deck();
            
        }

        public void StartGame()
        {
            Player = new Player(this);
            Dealer = new Dealer(this);
            DealCards();
        }

        private void DealCards()
        {
            Deck.Shuffle();
            Player.Hit();
            Dealer.Hit();
            Player.Hit();
            Dealer.Hit();
        }

        public void EndRound()
        {
            // check who won or if a draw
            // do I print it here? or seperate printing to controller layer?
        }

        public bool IsPlayerWinner()
        {
            return Player.Hand.GetTotalValue() > Dealer.Hand.GetTotalValue();
        }

        public bool IsDraw()
        {
            return Player.Hand.GetTotalValue() == Dealer.Hand.GetTotalValue();
        }

    }
}
