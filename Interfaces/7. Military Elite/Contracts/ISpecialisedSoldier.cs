using Military.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
