using DevBubba.Core.Factory;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DevBubba.Core.Transformers.Instance
{
    public abstract class LinqExpressionTransformer<TExpression> : ILinqTransformer<TExpression> where TExpression: Expression
    {
        protected ILinqTransformerFactory LinqTransformerFactory { get; }


        public abstract ExpressionType ExpressionType { get; }

        public abstract LambdaExpression Transform<TFrom, TTo>(TExpression fromExpression);

        public LambdaExpression Transform<TFrom, TTo>(Expression fromExpression)
        {
            if (fromExpression.NodeType == ExpressionType)
                return Transform<TFrom,TTo>((TExpression)fromExpression);
            else
            {
                return Transform<TFrom, TTo>((TExpression)fromExpression);
                //var expressionTransformer = LinqTransformerFactory.Get<ILinqTransformer>
            }
        }

        public void Dispose()
        {
        }

       
    }
}
