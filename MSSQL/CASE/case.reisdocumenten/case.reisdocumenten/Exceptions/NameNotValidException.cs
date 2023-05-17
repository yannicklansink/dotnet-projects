using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cases.reisdocumenten.Exceptions
{
    public class NameNotValidException : Exception
    {
        public NameNotValidException() { }

        public NameNotValidException(string message) : base(message) { }

        //public NameNotValidException(string message, Exception innerException) : base(message, innerException) { }

    }
}
