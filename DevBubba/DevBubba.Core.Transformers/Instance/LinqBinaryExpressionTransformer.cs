using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DevBubba.Core.Transformers.Instance
{
    public class LinqBinaryExpressionTransformer : LinqExpressionTransformer<BinaryExpression>
    {
        public override ExpressionType ExpressionType => throw new NotImplementedException();

        public override LambdaExpression Transform<TFrom, TTo>(BinaryExpression fromExpression)
        {
            throw new NotImplementedException();
        }
    }
}
