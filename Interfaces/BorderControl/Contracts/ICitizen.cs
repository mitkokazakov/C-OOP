using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Contracts
{
    public interface ICitizen :IIdentity
    {
        string Name { get; }

        int Age { get; }

    }
}
