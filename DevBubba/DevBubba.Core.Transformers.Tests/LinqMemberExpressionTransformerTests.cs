using Autofac.Extras.Moq;
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
            _mock = AutoMock.GetLoose();
            _mock.Provide<ILinqExpressionTransformer<MemberExpression>, LinqMemberExpressionTransformer>();


        }

        [TestCleanup]
        public void CleanUp()
        {
            _mock.Dispose();
        }

        [TestMethod]
        public void Test_LinqBinaryExpressionTransformer_Transform_Correct_From_To()
        {
            var memberExpressionLinqTransformer = _mock.Create<ILinqExpressionTransformer<MemberExpression>>();

            Func<From, object> from = fromObject => fromObject.Property;

            //https://stackoverflow.com/questions/14907327/how-to-convert-funct-bool-to-expressionfunct-bool

            var fromMemberExpression = Expression.PropertyOrField(Expression.Parameter(typeof(From)), "Property");

            var toMemberExpression = memberExpressionLinqTransformer.Transform<From, To>(fromMemberExpression);

            var toClass = new To { Property = "Success" };
            var toLinq = toMemberExpression.Compile();

            var result = toLinq.DynamicInvoke(toClass).ToString();
            Assert.AreEqual(result, toClass.Property.ToString());
        }
    }
}
