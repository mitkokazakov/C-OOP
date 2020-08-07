using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Exceptions
{
    public class InvalidCorpsException : Exception
    {
        private const string message = "Invalid corps!!";
        public InvalidCorpsException() : base(message)
        {

        }

        public InvalidCorpsException(string message) : base(message)
        {
        }
    }
}
