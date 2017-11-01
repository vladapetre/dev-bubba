using DevBubba.Core.Factory;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DevBubba.Core.Transformers.Instance
{
    public abstract class LinqExpressionTransformer<TExpression> : ILinqExpressionTransformer<TExpression> where TExpression: Expression
    {
        protected INamedInstanceFactory LinqTransformerFactory { get; }


        public abstract ExpressionType ExpressionType { get; }

        public abstract LambdaExpression Transform<TFrom, TTo>(TExpression fromExpression);

        public LambdaExpression Transform<TFrom, TTo>(Expression fromExpression)
        {
            if (fromExpression.NodeType == ExpressionType)
                return Transform<TFrom,TTo>((TExpression)fromExpression);
            else
            {
                var expressionTransformer = LinqTransformerFactory.Get<ILinqExpressionTransformer>(Enum.GetName(typeof(ExpressionType), fromExpression.NodeType));
                return expressionTransformer.Transform<TFrom, TTo>(fromExpression);
            }
        }

        public void Dispose()
        {
        }

       
    }
}
