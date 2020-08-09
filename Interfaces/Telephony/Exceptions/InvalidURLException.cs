using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Exceptions
{
    public class InvalidURLException : Exception
    {
        private const string message = "Invalid URL!";
        public InvalidURLException() : base(message)
        {

        }

        public InvalidURLException(string message) : base(message)
        {

        }
    }
}
