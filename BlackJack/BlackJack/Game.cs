using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Game
    {

        public int RoundNumber = 0;
        public bool StillPlaying { get; set; }

        public Deck Deck;
        public Player Player { get; set; }
        public Dealer Dealer { get; set; }

        public Game()
        {
            StillPlaying = true;
            Deck = new Deck();
            ShuffleDeck();
            Player = new Player(this);
        }

        public void StartRound(decimal bet)
        {
            Dealer = new Dealer(this);
            Player.NewRound();
            Player.Bet = bet;
            RoundNumber++;
            StillPlaying = true;
            DealCards();
        }

        public void DealCards()
        {
            Player.Hit();
            Dealer.Hit();
            Player.Hit();
            Dealer.Hit();
        }

        // is dit mooi?
        // je zou nu dit kunnen doen: game.ShuffleDeck();
        // maar ook:                  game.Deck.Shuffle();
        public void ShuffleDeck()
        {
            Deck.Shuffle();
        }

        public void EndRound()
        {
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
                // dealer won
            }
        }

        public bool IsPlayerWinner()
        {
            return (Player.Hand.GetTotalValue() > Dealer.Hand.GetTotalValue() && !Player.IsBust()) || (!Player.IsBust() && Dealer.IsBust());
        }

        public bool IsDraw()
        {
            return Player.Hand.GetTotalValue() == Dealer.Hand.GetTotalValue() && !Player.IsBust() && !Dealer.IsBust();
        }

        
    }
}
