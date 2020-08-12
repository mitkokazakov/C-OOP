using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Exceptions
{
    public class InvalidFood : Exception
    {
        public InvalidFood(string message) : base(message)
        {
        }
    }
}
