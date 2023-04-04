using BlackJack.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Card
    {

        private Rank Rank { get; }
        private Suit Suit { get; }

        public int Value
        {
            get
            {
                int value;
                switch (Rank)
                {
                    case Rank.Ace:
                        value = 11;
                        break;
                    case Rank.King:
                    case Rank.Queen:
                    case Rank.Jack:
                    case Rank.Ten:
                        value = 10;
                        break;
                    case Rank.Nine:
                        value = 9;
                        break;
                    case Rank.Eight:
                        value = 8;
                        break;
                    case Rank.Seven:
                        value = 7;
                        break;
                    case Rank.Six:
                        value = 6;
                        break;
                    case Rank.Five:
                        value = 5;
                        break;
                    case Rank.Four:
                        value = 4;
                        break;
                    case Rank.Three:
                        value = 3;
                        break;
                    case Rank.Two:
                        value = 2;
                        break;
                    default:
                        throw new RankNotFoundException("We don't have that Rank value in our system.");
                }
                return value;
            }
        }

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }

        
    }
}
