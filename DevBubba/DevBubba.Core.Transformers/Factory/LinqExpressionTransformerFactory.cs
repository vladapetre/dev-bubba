using Autofac;
using DevBubba.Core.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevBubba.Core.Transformers.Factory
{
    public class LinqExpressionTransformerFactory : INamedInstanceFactory
    {
        private readonly IComponentContext _container;

        public LinqExpressionTransformerFactory(IComponentContext container)
        {
            _container = container;
        }

        public TType Get<TType>()
        {
            return _container.Resolve<TType>();
        }

        public TType GetNamed<TType>(string namedInstance)
        {
            return _container.ResolveNamed<TType>(namedInstance);
        }
    }
}
