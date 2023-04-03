using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Exceptions
{
    public class RankNotFoundException : Exception
    {
        public RankNotFoundException()
        {
        }

        public RankNotFoundException(string message) : base(message)
        {
        }
    }
}
