using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<ISoldier> Privates { get; }

        void AddPrivates(ISoldier @private);
        
    }
}
