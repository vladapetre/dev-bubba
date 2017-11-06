﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DevBubba.Core.Factory;

namespace DevBubba.Core.Transformers.Instance.Binary
{
    public class LinqSubstractExpressionTransformer : LinqBinaryExpressionTransformer
    {
        public LinqSubstractExpressionTransformer(INamedInstanceFactory namedInstanceFactory) : base(namedInstanceFactory)
        {
        }

        public override ExpressionType ExpressionType => ExpressionType.Subtract;
    }
}
