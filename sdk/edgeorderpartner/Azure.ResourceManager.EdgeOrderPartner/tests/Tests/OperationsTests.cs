// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.EdgeOrderPartner.Tests.Tests
{
    [TestFixture]
    public class OperationsTests : EdgeOrderPartnerManagementClientBase
    {
        public OperationsTests() : base(true)
        {
        }

        [SetUp]
        public void ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeClients();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [TestCase]
        public async Task ListOperationsTest()
        {
            var operations = EdgeOrderPartnerManagementOperations.ListOperationsPartnerAsync();
            var operationsResult = await operations.ToEnumerableAsync();

            Assert.NotNull(operationsResult);
            Assert.IsTrue(operationsResult.Count >= 1);
        }
    }
}
