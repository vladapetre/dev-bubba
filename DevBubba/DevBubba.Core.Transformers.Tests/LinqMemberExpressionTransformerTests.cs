using Autofac;
using Autofac.Extras.Moq;
using DevBubba.Core.Factory;
using DevBubba.Core.Transformers.Instance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace DevBubba.Core.Transformers.Tests
{
    [TestClass]
    public class LinqMemberExpressionTransformerTests
    {
        private AutoMock _mock;

        [TestInitialize]
        public void Initialize()
        {
            var container = Container.Get();
            _mock = AutoMock.GetLoose();
            _mock.Provide<INamedInstanceFactory>(container.Resolve<INamedInstanceFactory>());
            _mock.Provide<ILinqExpressionTransformer<LambdaExpression>, LinqLambdaExpressionTransformer>();

        }

        [TestCleanup]
        public void CleanUp()
        {
            _mock.Dispose();
        }

        [TestMethod]
        public void Test_LinqBinaryExpressionTransformer_Transform_Correct_From_To()
        {
            var memberExpressionLinqTransformer = _mock.Create<ILinqExpressionTransformer<LambdaExpression>>();

            Expression<Func<From, object>> expr = exp => exp.Property;

            var toMemberExpression = memberExpressionLinqTransformer.Transform<From, To>(expr);

            var toClass = new To { Property = "Success" };
            var toLinq = toMemberExpression.Compile();

            var result = toLinq.DynamicInvoke(toClass).ToString();
            Assert.AreEqual(result, toClass.Property.ToString());
        }
    }
}
