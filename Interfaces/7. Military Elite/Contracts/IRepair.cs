using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Contracts
{
    public interface IRepair
    {
        string PartName { get; }

        int HoursWorked { get; }
    }
}
