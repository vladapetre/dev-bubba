using Autofac;
using DevBubba.Core.Factory;
using DevBubba.Core.Transformers.Factory;
using DevBubba.Core.Transformers.Instance;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DevBubba.Core.Transformers.Tests
{
    public static class Container
    {
        public static IContainer Get()
        {
            var builder = new ContainerBuilder();

            // Register individual components
            builder.RegisterType<LinqExpressionTransformerFactory>().As<INamedInstanceFactory>();
            builder.RegisterType<LinqMemberExpressionTransformer>().Named<ILinqExpressionTransformer>(Enum.GetName(typeof(ExpressionType), ExpressionType.MemberAccess));
            builder.RegisterType<LinqLambdaExpressionTransformer>().Named<ILinqExpressionTransformer>(Enum.GetName(typeof(ExpressionType), ExpressionType.Lambda));
            builder.RegisterType<LinqAddExpressionTransformer>().Named<ILinqExpressionTransformer>(Enum.GetName(typeof(ExpressionType), ExpressionType.Add));
            var container = builder.Build();

            return container;
        }
    }
}
