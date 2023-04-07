using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Hand
    {
        public List<Card> CardList {  get; set; }

        public Hand()
        {
            CardList = new List<Card>();
        }

        public void AddCard(Card card)
        {
            CardList.Add(card);
        }

        public int GetTotalValue()
        {
            int value = 0;
            int numberOfAces = 0;

            foreach (Card card in CardList)
            {
                value += card.Value;

                if (card.Rank == Rank.Ace)
                {
                    numberOfAces++;
                }
            }

            while (value > 21 && numberOfAces > 0)
            {
                value -= 10;
                numberOfAces--;
            }

            return value;
        }

        public int GetHandSize()
        {
            return CardList.Count;
        }

       

        public override string ToString()
        {
            string result = "";
            foreach (Card card in CardList)
            {
                result += "\t" + card.ToString() + "\n";
            }
            return result;
        }

    }
}
