using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Exceptions
{
    public class InvalidStateException : Exception
    {
        private const string message = "Invalid state!!";
        public InvalidStateException() : base(message)
        {

        }

        public InvalidStateException(string message) : base(message)
        {

        }
    }
}
