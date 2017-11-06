using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using DevBubba.Core.Factory;

namespace DevBubba.Core.Transformers.Instance
{
    public class LinqMemberExpressionTransformer : LinqExpressionTransformer<MemberExpression>
    {
        public LinqMemberExpressionTransformer(INamedInstanceFactory namedInstanceFactory) : base(namedInstanceFactory)
        {
        }

        public override ExpressionType ExpressionType => ExpressionType.MemberAccess;

        public override MemberExpression Transform<TFrom, TTo>(MemberExpression fromExpression)
        {
            var toParameterExpression = Expression.Parameter(typeof(TTo));
            var toMemberExpression = Expression.PropertyOrField(toParameterExpression, fromExpression.Member.Name);

            return toMemberExpression;
        }
    }
}
