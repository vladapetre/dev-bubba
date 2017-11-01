using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DevBubba.Core.Transformers
{
    public interface ILinqTransformer<TExpression> : ITransformer where TExpression : Expression
    {
        LambdaExpression Transform<TFrom, TTo>(Expression fromExpression);

        LambdaExpression Transform<TFrom, TTo>(TExpression fromExpression); 
    }
}
