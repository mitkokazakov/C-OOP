using Military.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Contracts
{
    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}
