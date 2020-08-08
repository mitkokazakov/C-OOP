using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Contracts
{
    public interface ICitizen : IBuyer
    {

        int Age { get; }

        string Id { get; }

        string Birthdate { get; }
    }
}
