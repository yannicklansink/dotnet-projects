﻿using BlackJack.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Player : IMoves
    {

        private decimal _balance;
        private decimal _bet;
        public bool IsStand { get; set; }
        

        public Player(Game game, string name = "Player", decimal saldo = 20m) : base(game, name)
        {
            _balance = saldo;
            IsStand = false;

        }

        public decimal Bet
        {
            get { return _bet; }
            set
            {
                if (!IsBetHigherThenBalance(value))
                {
                    Balance = Balance - value;
                    _bet = value;
                }
                else
                {
                    throw new BetIsHigherThenBalanceException($"Your bet of {value} is higher then your balance of {Balance}");
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
            // skip.
            // dealer moet kaart omdraaien. -> dealer moet hit aanroepen totdat 
            IsStand = true;
            Game.Dealer.Play();
        }

        public bool IsBetHigherThenBalance(decimal bet)
        {
            return bet > Balance;
        }

        public bool CanPlayAnotherRound()
        {
            return Balance > 0m;
        }

        public override string ShowHand()
        {
            // return a string of hand
            //return "Player hand: \n" + Hand.ToString() + "\t(Hand value is)" + Hand.GetTotalValue() + "\n\t" + "(bet: ) " + Bet;
            return $"Player hand: \n {Hand.ToString()} \t(Hand value is: {Hand.GetTotalValue()})\n\t(bet: {Bet})\n";
        }
    }
}
