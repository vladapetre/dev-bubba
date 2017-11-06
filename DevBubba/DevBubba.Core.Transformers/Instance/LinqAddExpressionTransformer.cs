using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DevBubba.Core.Factory;

namespace DevBubba.Core.Transformers.Instance
{
    public class LinqAddExpressionTransformer : LinqBinaryExpressionTransformer
    {
        public LinqAddExpressionTransformer(INamedInstanceFactory namedInstanceFactory) : base(namedInstanceFactory)
        {
        }

        public override ExpressionType ExpressionType => ExpressionType.Add;
    }
}
