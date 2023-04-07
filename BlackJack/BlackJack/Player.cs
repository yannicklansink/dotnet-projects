using BlackJack.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Player : Moves
    {

        private decimal _balance;
        private decimal _bet;
        public bool IsStand { get; set; }

        public Player(Game game, string name = "Player", decimal balance = 20m) : base(game, name)
        {
            _balance = balance;
            IsStand = false;
        }

        public decimal Bet
        {
            get { return _bet; }
            set
            {
                if (!IsBetHigherThenBalance(value) && !IsBetLessThen1(value))
                {
                    Balance = Balance - value;
                    _bet = value;
                }
                else
                {
                    throw new BetIsInvalidException($"Your bet of {value} is invalid. Your balance is: {Balance}");
                }
            }
        }

        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; } // do you want to be able to change balance from other classes?
        }

        public void Stand()
        {
            IsStand = true;
            Game.Dealer.Play();
        }


        public bool IsBetHigherThenBalance(decimal bet)
        {
            return bet > Balance;
        }

        public bool IsBetLessThen1(decimal bet)
        {
            return bet < 1m;
        }

        public bool CanPlayAnotherRound()
        {
            return Balance >= 1m;
        }

        public void NewRound()
        {
            IsStand = false;
            _bet = 0m;
            Hand = new Hand();
        }

        public override string ShowHand()
        {
            return $"Player hand: \n {Hand.ToString()} \t(Hand value is: {Hand.GetTotalValue()})\n\t(bet: {Bet})\n";
        }
    }
}
