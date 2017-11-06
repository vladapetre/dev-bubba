using Autofac;
using Autofac.Extras.Moq;
using DevBubba.Core.Factory;
using DevBubba.Core.Transformers.Factory;
using DevBubba.Core.Transformers.Instance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;

namespace DevBubba.Core.Transformers.Tests
{

    [TestClass]
    public class LinqBinaryExpressionTransformerTests
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
            var binaryExpressionLinqTransformer = _mock.Create<ILinqExpressionTransformer<LambdaExpression>>();
            Expression<Func<From, int>> expr = exp => exp.Number + exp.Number;

            var transformed = binaryExpressionLinqTransformer.Transform<From, To>(expr);

            var compiled = transformed.Compile();
            var result = compiled.DynamicInvoke(new To { Number = 5 });

            Assert.AreEqual(result, 10);
        }
    }
}
