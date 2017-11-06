using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DevBubba.Core.Factory;

namespace DevBubba.Core.Transformers.Instance
{
    public class LinqLambdaExpressionTransformer : LinqExpressionTransformer<LambdaExpression>
    {
        public LinqLambdaExpressionTransformer(INamedInstanceFactory namedInstanceFactory) : base(namedInstanceFactory)
        {
        }

        public override ExpressionType ExpressionType => ExpressionType.Lambda;

        public override LambdaExpression Transform<TFrom, TTo>(LambdaExpression fromExpression)
        {
            var body = fromExpression.Body;

            var trasnformedBody = Transform<TFrom, TTo>(body);
            var toParameter = Expression.Parameter(typeof(TTo));
            var transformedExpression = VisitParameter<TTo>(Expression.Lambda(trasnformedBody, toParameter), toParameter);

            return transformedExpression;
        }
    }
}
