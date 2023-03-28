using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag11.PutItAllToghether.Exceptions
{
    public class ArgumentDoesNotExistsException : Exception
    {
        public ArgumentDoesNotExistsException()
        {
        }

        public ArgumentDoesNotExistsException(string message) : base(message)
        {
        }

    }
}
