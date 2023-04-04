using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Exceptions
{
    public class CardListEmptyException : Exception
    {
        public CardListEmptyException()
        {
        }

        public CardListEmptyException(string message) : base(message)
        {
        }
    }
}
