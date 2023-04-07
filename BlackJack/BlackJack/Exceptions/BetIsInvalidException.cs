using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Exceptions
{
    public class BetIsInvalidException : Exception
    {
        public BetIsInvalidException()
        {
        }

        public BetIsInvalidException(string message) : base(message)
        {
        }
    }
}
