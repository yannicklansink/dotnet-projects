using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Exceptions
{
    public class UserInputIsInvalidException : Exception
    {
        public UserInputIsInvalidException()
        {
        }

        public UserInputIsInvalidException(string message) : base(message)
        {
        }
    }
}
