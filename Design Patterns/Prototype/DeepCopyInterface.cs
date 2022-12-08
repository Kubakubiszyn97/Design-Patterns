﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Prototype
{
    public interface IPrototype<T>
    {
        T DeepCopy();
    }
}
