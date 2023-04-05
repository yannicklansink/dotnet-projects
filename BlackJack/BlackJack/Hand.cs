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
            // Do I have to check if the score (value) is over 21? So BUST?????
            CardList.Add(card);
        }

        public int GetTotalValue()
        {
            int value = 0;
            foreach (Card card in CardList)
            {
                value += card.Value;
            }
            return value;
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
