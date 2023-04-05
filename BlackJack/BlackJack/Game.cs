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
        private int? RoundNumber;
        public Deck Deck;
        public Player Player { get; set; }
        public Dealer Dealer { get; set; }

        public Game()
        {
            Deck = new Deck();
            Player = new Player(this);
            Dealer = new Dealer(this);
        }

        public void StartGame(decimal bet)
        {
            Player.Bet = bet;
            RoundNumber = 1;
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
            // do I print it here? or seperate printing to controller layer?
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
            if (Player.CanPlayAnotherRound())
            {
                AskIfPlayerWantsToPlayAnotherRound();
            }
        }

        public void AskIfPlayerWantsToPlayAnotherRound()
        {
            
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
