using Autofac;
using DevBubba.Core.Factory;
using DevBubba.Core.Transformers.Factory;
using DevBubba.Core.Transformers.Instance;
using DevBubba.Core.Transformers.Instance.Binary;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Linq;

namespace DevBubba.Core.Transformers.Tests
{
    public static class Container
    {
        public static IContainer Get()
        {
            var builder = new ContainerBuilder();

            // Register individual components
            builder.RegisterType<LinqExpressionTransformerFactory>().As<INamedInstanceFactory>();




            builder.RegisterAssemblyTypes(typeof(ILinqExpressionTransformer).GetTypeInfo().Assembly, typeof(LinqExpressionTransformerFactory).GetTypeInfo().Assembly)
                .Where(t => t.IsAssignableTo<ILinqExpressionTransformer>() && Enum.GetNames(typeof(ExpressionType)).Any(name => t.Name.Contains($"Linq{name}ExpressionTransformer")))
                .Named<ILinqExpressionTransformer>(t =>
                {
                    return Enum.GetNames(typeof(ExpressionType)).FirstOrDefault(name => t.Name.Contains($"Linq{name}ExpressionTransformer"));
                });

            //builder.RegisterType<LinqMemberExpressionTransformer>().Named<ILinqExpressionTransformer>(Enum.GetName(typeof(ExpressionType), ExpressionType.MemberAccess));
            //builder.RegisterType<LinqLambdaExpressionTransformer>().Named<ILinqExpressionTransformer>(Enum.GetName(typeof(ExpressionType), ExpressionType.Lambda));
            //builder.RegisterType<LinqAddExpressionTransformer>().Named<ILinqExpressionTransformer>(Enum.GetName(typeof(ExpressionType), ExpressionType.Add));
            //builder.RegisterType<LinqSubstractExpressionTransformer>().Named<ILinqExpressionTransformer>(Enum.GetName(typeof(ExpressionType), ExpressionType.Subtract));
            //builder.RegisterType<LinqEqualExpressionTransformer>().Named<ILinqExpressionTransformer>(Enum.GetName(typeof(ExpressionType), ExpressionType.Equal));
            //builder.RegisterType<LinqAndAlsoExpressionTransformer>().Named<ILinqExpressionTransformer>(Enum.GetName(typeof(ExpressionType), ExpressionType.AndAlso));
            //builder.RegisterType<LinqConstantExpressionTransformer>().Named<ILinqExpressionTransformer>(Enum.GetName(typeof(ExpressionType), ExpressionType.Constant));
            var container = builder.Build();

            return container;
        }
    }
}
