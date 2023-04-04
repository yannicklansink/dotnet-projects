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

        public void StartGame(decimal bet) // check if bet isnt higher then player balance
        {
            Player = new Player(this, bet);
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
            // change players _saldo with _bet amount.
            Console.WriteLine("Round ended");
            if (IsPlayerWinner())
            {
                // player won
                Player.Balance = Player.Balance + (Player.Bet * 2);
            }
            else if (IsDraw())
            {
                // draw
                Player.Balance = Player.Balance + Player.Bet;
            } else
            {
                // Dealer won
                Console.WriteLine("Dealer won");
            }


        }

        public bool IsPlayerWinner()
        {
            return Player.Hand.GetTotalValue() > Dealer.Hand.GetTotalValue() && !Player.IsBust() || !Player.IsBust() && Dealer.IsBust();
        }

        public bool IsDraw()
        {
            return Player.Hand.GetTotalValue() == Dealer.Hand.GetTotalValue() && !Player.IsBust() && !Dealer.IsBust();
        }

    }
}
