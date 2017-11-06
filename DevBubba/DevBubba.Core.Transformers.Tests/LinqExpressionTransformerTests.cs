using Autofac;
using Autofac.Extras.Moq;
using DevBubba.Core.Factory;
using DevBubba.Core.Transformers.Instance;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DevBubba.Core.Transformers.Tests
{
    [TestClass]
    public class LinqExpressionTransformerTests
    {
        private AutoMock _mock;
        private LinqLambdaExpressionTransformer _lambdaExpressionTransformer;
        private To _to;

        [TestInitialize]
        public void Initialize()
        {
            var container = Container.Get();
            _mock = AutoMock.GetLoose();
            _mock.Provide(container.Resolve<INamedInstanceFactory>());
            _mock.Provide<ILinqExpressionTransformer<LambdaExpression>, LinqLambdaExpressionTransformer>();

            _lambdaExpressionTransformer = _mock.Create<LinqLambdaExpressionTransformer>();
            _to = new To { String = "TestString", Number = 10 };
        }

        [TestCleanup]
        public void CleanUp()
        {
            _mock.Dispose();
            _lambdaExpressionTransformer.Dispose();
        }

        [TestMethod]
        public void Test_LinqMemberExpressionTransformer_From_To_Success()
        {
            Expression<Func<From, string>> expr = from => from.String;

            var transformedExpr = _lambdaExpressionTransformer.Transform<From, To>(expr);

            var function = transformedExpr.Compile();
            var result = function.DynamicInvoke(_to);

            Assert.AreEqual(result, _to.String);
            Assert.AreSame(result, _to.String);
        }

        [TestMethod]
        public void Test_LinqConstantExpressionTransformer_From_To_Success()
        {
            Expression<Func<From, string>> expr = from => "Hello";

            var transformedExpr = _lambdaExpressionTransformer.Transform<From, To>(expr);

            var function = transformedExpr.Compile();
            var result = function.DynamicInvoke(_to);

            Assert.AreEqual(result, "Hello");
        }

        [TestMethod]
        public void Test_LinqAddExpressionTransformer_From_To_Success()
        {
            Expression<Func<From, int>> expr = from => from.Number + from.Number;

            var transformedExpr = _lambdaExpressionTransformer.Transform<From, To>(expr);

            var function = transformedExpr.Compile();
            var result = function.DynamicInvoke(_to);

            Assert.AreEqual(result, _to.Number + _to.Number);
        }

        [TestMethod]
        public void Test_LinqSubstractExpressionTransformer_From_To_Success()
        {
            Expression<Func<From, int>> expr = from => from.Number - from.Number;

            var transformedExpr = _lambdaExpressionTransformer.Transform<From, To>(expr);

            var function = transformedExpr.Compile();
            var result = function.DynamicInvoke(_to);

            Assert.AreEqual(result, _to.Number - _to.Number);
        }

        [TestMethod]
        public void Test_LinqEqualsExpressionTransformer_From_To_Success()
        {
            Expression<Func<From, bool>> expr = from => from.Number == from.Number;

            var transformedExpr = _lambdaExpressionTransformer.Transform<From, To>(expr);

            var function = transformedExpr.Compile();
            var result = function.DynamicInvoke(_to);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void Test_LinqAndAlsoExpressionTransformer_From_To_Success()
        {
            Expression<Func<From, bool>> expr = from => from.Number == from.Number && from.String == from.String;

            var transformedExpr = _lambdaExpressionTransformer.Transform<From, To>(expr);

            var function = transformedExpr.Compile();
            var result = function.DynamicInvoke(_to);

            Assert.AreEqual(result, true);
        }
    }
}
