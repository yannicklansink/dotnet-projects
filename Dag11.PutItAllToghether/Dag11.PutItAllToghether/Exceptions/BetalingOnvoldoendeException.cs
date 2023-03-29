using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag11.PutItAllToghether.Exceptions
{
    public class BetalingOnvoldoendeException : Exception
    {
        public BetalingOnvoldoendeException()
        {
        }

        public BetalingOnvoldoendeException(string message) : base(message)
        {
        }

    }
}
