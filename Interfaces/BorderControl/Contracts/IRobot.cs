using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Contracts
{
    public interface IRobot : IIdentity
    {
        string Model { get; }

    }
}
