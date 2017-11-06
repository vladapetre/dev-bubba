using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DevBubba.Core.Factory;

namespace DevBubba.Core.Transformers.Instance
{
    public class LinqConstantExpressionTransformer : LinqExpressionTransformer<ConstantExpression>
    {
        public LinqConstantExpressionTransformer(INamedInstanceFactory namedInstanceFactory) : base(namedInstanceFactory)
        {
        }

        public override ExpressionType ExpressionType => ExpressionType.Constant;

        public override ConstantExpression Transform<TFrom, TTo>(ConstantExpression fromExpression)
        {
            var transformedExpression = Expression.Constant(fromExpression.Value, fromExpression.Type);
            return transformedExpression;
        }
    }
}
