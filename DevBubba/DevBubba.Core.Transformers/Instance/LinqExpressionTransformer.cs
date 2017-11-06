using DevBubba.Core.Factory;
using DevBubba.Core.Transformers.Helpers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DevBubba.Core.Transformers.Instance
{
    public abstract class LinqExpressionTransformer<TExpression> : ILinqExpressionTransformer<TExpression> where TExpression: Expression
    {
        protected INamedInstanceFactory LinqTransformerFactory { get; set; }

        protected LinqExpressionTransformer(INamedInstanceFactory namedInstanceFactory)
        {
            LinqTransformerFactory = namedInstanceFactory;
        }

        public abstract ExpressionType ExpressionType { get; }

        public abstract TExpression Transform<TFrom, TTo>(TExpression fromExpression);

        public Expression Transform<TFrom, TTo>(Expression fromExpression)
        {
            if (fromExpression.NodeType == ExpressionType)
                return Transform<TFrom,TTo>((TExpression)fromExpression);
            else
            {
                var expressionTransformer = LinqTransformerFactory.GetNamed<ILinqExpressionTransformer>(Enum.GetName(typeof(ExpressionType), fromExpression.NodeType));
                return expressionTransformer.Transform<TFrom, TTo>(fromExpression);
            }
        }

#pragma warning disable CC0091 // Use static method
        protected TExpression VisitParameter<TTo>(TExpression tranformedExpression, ParameterExpression parameterExpression)
#pragma warning restore CC0091 // Use static method
        {
                       return new ParameterReplacer(parameterExpression).Visit(tranformedExpression) as TExpression;
        }

        public void Dispose()
        {
        }

       
    }
}
