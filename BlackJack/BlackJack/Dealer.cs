using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Dealer : Moves
    {
        public bool IsPlaying = false;

        public Dealer(Game game, string name = "Dealer") : base(game, name)
        {

        }

        public List<Card> GetCards()
        {
            return Hand.CardList;
        }


        public void Play()
        {
            IsPlaying = true;
            while (!IsBust() && Hand.GetTotalValue() < 17)
            {
                Hit();
            }
        }

        public override string ShowHand()
        {
            //return "Dealer hand: \n" + Hand.ToString();
            string value = "Dealer hand:" + "\n";
            for (int i = 0; i < Hand.CardList.Count; i++)
            {
                if (i == 0)
                {
                    value += "\t## Face Down ##\n";
                    continue;
                }
                value += "\t" + Hand.CardList[i];
            }

            return value;
        }

        public string ShowHandWithoutFaceDown()
        {
            return $"Dealer hand: \n {Hand.ToString()} \t(Hand value is: {Hand.GetTotalValue()})\n";
        }

    }
}
