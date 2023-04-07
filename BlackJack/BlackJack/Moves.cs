using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public abstract class Moves
    {
        public Hand Hand { get; set; }
        public Game Game { get; }

        public string Name { get; set; }

        public Moves(Game game, string name)
        {
            Game = game;
            Name = name;
            Hand = new Hand();
        }

        public abstract string ShowHand();

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
