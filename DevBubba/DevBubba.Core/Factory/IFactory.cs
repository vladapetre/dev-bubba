﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DevBubba.Core.Factory
{
    public interface IFactory
    {
        TType Get<TType>();
        TType Get<TType>(string namedInstance);
    }
}
