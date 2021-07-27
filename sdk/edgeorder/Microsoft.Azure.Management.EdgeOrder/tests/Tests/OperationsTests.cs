using Microsoft.Azure.Management.EdgeOrder;
using Microsoft.Azure.Management.EdgeOrder.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.Azure;
using System;
using Xunit;
using Xunit.Abstractions;

namespace EdgeOrder.Tests
{
    public class OperationsTests : EdgeOrderTestBase
    {
        public OperationsTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        [Fact]
        public void TestOperationsAPI()
        {
            try
            {
                //operations allowed
                var operations = GetOperations();
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }

        private IPage<Operation> GetOperations()
        {
            var operations = this.Client.Operations.List();

            Assert.True(operations != null, "List call for Operations was not successful.");

            return operations;
        }
    }
}
