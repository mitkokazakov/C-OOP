﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Contracts
{
    public interface IRobot
    {
        string Model { get; }

        string Id { get;  }
    }
}
