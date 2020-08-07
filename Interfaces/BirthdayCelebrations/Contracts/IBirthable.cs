using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Contracts
{
    public interface IBirthable
    {
        string Name { get; }

        string Birthdate { get; }
    }
}
