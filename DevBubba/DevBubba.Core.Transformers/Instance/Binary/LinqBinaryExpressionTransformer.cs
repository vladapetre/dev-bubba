using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DevBubba.Core.Factory;
using DevBubba.Core.Transformers.Helpers;

namespace DevBubba.Core.Transformers.Instance.Binary
{
    public abstract class LinqBinaryExpressionTransformer : LinqExpressionTransformer<BinaryExpression>
    {
        protected LinqBinaryExpressionTransformer(INamedInstanceFactory namedInstanceFactory) : base(namedInstanceFactory)
        {
        }

        public abstract override ExpressionType ExpressionType { get; }

        public override BinaryExpression Transform<TFrom, TTo>(BinaryExpression fromExpression)
        {
            var rightExpressiont = fromExpression.Right;
            var leftExpression = fromExpression.Left;

            var transformedRight = Transform<TFrom, TTo>(rightExpressiont);
            var transformedLeft = Transform<TFrom, TTo>(leftExpression);

            var toParameter = Expression.Parameter(typeof(TTo));
            var tranformedExpression = Expression.MakeBinary(ExpressionType, transformedLeft, transformedRight);
            var visitedExpression = VisitParameter<TTo>(tranformedExpression, toParameter);

            return visitedExpression;
        }

        
    }
}
