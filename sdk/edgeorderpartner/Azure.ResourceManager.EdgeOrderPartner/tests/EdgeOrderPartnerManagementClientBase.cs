// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.EdgeOrderPartner.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    public abstract class EdgeOrderPartnerManagementClientBase : ManagementRecordedTestBase<EdgeOrderPartnerManagementTestEnvironment>
    {
        public string SubscriptionId { get; set; }
        public ResourcesManagementClient ResourcesManagementClient { get; set; }
        public ResourceGroupsOperations ResourceGroupsOperations { get; set; }
        public EdgeOrderPartnerManagementClient EdgeOrderPartnerManagementClient { get; set; }
        public EdgeOrderPartnerManagementOperations EdgeOrderPartnerManagementOperations { get; set; }

        protected EdgeOrderPartnerManagementClientBase(bool isAsync) : base(isAsync)
        {
            Sanitizer = new EdgeOrderPartnerManagementRecordedTestSanitizer();
        }

        protected void InitializeClients()
        {
            SubscriptionId = TestEnvironment.SubscriptionId;
            ResourcesManagementClient = GetResourceManagementClient();
            ResourceGroupsOperations = ResourcesManagementClient.ResourceGroups;
            EdgeOrderPartnerManagementClient = GetEdgeOrderPartnerManagementClient();
            EdgeOrderPartnerManagementOperations = EdgeOrderPartnerManagementClient.EdgeOrderPartnerManagement;
        }

        internal EdgeOrderPartnerManagementClient GetEdgeOrderPartnerManagementClient()
        {
            return CreateClient<EdgeOrderPartnerManagementClient>(SubscriptionId,
                TestEnvironment.Credential,
                InstrumentClientOptions(new EdgeOrderPartnerManagementClientOptions()));
        }
    }
}
