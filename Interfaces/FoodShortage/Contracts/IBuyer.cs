using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Contracts
{
    public interface IBuyer
    {
        string Name { get; }

        void BuyFood();

        int Food { get; }
    }
}
