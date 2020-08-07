using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Contracts
{
    public interface ICitizen : IBirthable
    {
       
        int Age { get; }

        string Id { get;  }
    }
}
