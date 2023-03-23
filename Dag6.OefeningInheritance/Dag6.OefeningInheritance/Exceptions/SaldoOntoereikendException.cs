using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag6.OefeningInheritance
{
    public class SaldoOntoereikendException : Exception
    {
        public SaldoOntoereikendException()
        {
        }

        public SaldoOntoereikendException(string message) : base(message)
        {

        }
    }
}
