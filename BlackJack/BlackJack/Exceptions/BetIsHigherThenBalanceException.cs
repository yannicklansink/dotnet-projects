using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Exceptions
{
    public class BetIsHigherThenBalanceException : Exception
    {
        public BetIsHigherThenBalanceException()
        {
        }

        public BetIsHigherThenBalanceException(string message) : base(message)
        {
        }
    }
}
