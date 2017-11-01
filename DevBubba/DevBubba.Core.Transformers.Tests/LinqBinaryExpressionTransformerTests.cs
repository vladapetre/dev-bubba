using Autofac.Extras.Moq;
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
            _mock = AutoMock.GetLoose();
            _mock.Provide<LinqBinaryExpressionTransformerTests, ILinqExpressionTransformer<BinaryExpression>>();

            
        }

        [TestCleanup]
        public void CleanUp()
        {
            _mock.Dispose();
        }

        [TestMethod]
        public void Test_LinqBinaryExpressionTransformer_Transform_Correct_From_To()
        {
            var binaryExpressionLinqTransformer = _mock.Create<ILinqExpressionTransformer<BinaryExpression>>();
            throw new NotImplementedException();
        }
    }
}
