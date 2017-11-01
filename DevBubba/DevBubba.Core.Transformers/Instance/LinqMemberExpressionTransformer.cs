using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace DevBubba.Core.Transformers.Instance
{
    public class LinqMemberExpressionTransformer : LinqExpressionTransformer<MemberExpression>
    {
        public override ExpressionType ExpressionType => ExpressionType.MemberAccess;

        public override LambdaExpression Transform<TFrom, TTo>(MemberExpression fromExpression)
        {
            var toParameterExpression = Expression.Parameter(typeof(TTo));
            var toMemberExpression = Expression.PropertyOrField(toParameterExpression, fromExpression.Member.Name);

            return Expression.Lambda(toMemberExpression, toParameterExpression);
        }
    }
}
