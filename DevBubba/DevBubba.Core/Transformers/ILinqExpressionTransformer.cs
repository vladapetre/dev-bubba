using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DevBubba.Core.Transformers
{

    public interface ILinqExpressionTransformer : ITransformer
    {
        LambdaExpression Transform<TFrom, TTo>(Expression fromExpression);
    }

    public interface ILinqExpressionTransformer<TExpression> : ILinqExpressionTransformer where TExpression : Expression
    {
        LambdaExpression Transform<TFrom, TTo>(TExpression fromExpression); 
    }
}
