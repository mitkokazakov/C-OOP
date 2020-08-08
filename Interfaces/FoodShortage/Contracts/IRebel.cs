using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Contracts
{
    public interface IRebel : IBuyer
    {

        int Age { get; }

        string Group { get; }
    }
}
