﻿using DevBubba.Core.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevBubba.Core.Transformers.Factory
{
    public class LinqTransformerFactory : ILinqTransformerFactory
    {
        public TType Get<TType>()
        {
            throw new NotImplementedException();
        }

        public TType Get<TType>(string namedInstance)
        {
            throw new NotImplementedException();
        }
    }
}
