﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public abstract class IMoves
    {
        public Hand Hand { get; }
        public Game Game { get; }

        public string Name { get; set; }

        public IMoves(Game game, string name)
        {
            Game = game;
            Name = name;
            Hand = new Hand();
        }

        public bool IsBust()
        {
            return Hand.GetTotalValue() > 21 ? true : false;
        }

        public void PrintBustNews()
        {
            Console.WriteLine($"{Name} is bust with a score of: {Hand.GetTotalValue()}");
        }

        public void Hit()
        {
            // add card to hand.
            Hand.AddCard(Game.Deck.Draw());
            if (IsBust())
            {
                PrintBustNews();
            }
        }
    }
}
