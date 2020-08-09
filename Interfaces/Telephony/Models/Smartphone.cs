using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Contracts;
using System.Linq;
using Telephony.Exceptions;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowseble
    {
        public Smartphone()
        {
                
        }
        public string Browse(string url)
        {
            if (url.Any(ch => Char.IsDigit(ch)))
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            if (!number.All(ch => Char.IsDigit(ch)))
            {
                throw new InvalidNumberException();
            }

            return $"Calling... {number}";
        }
    }
}
