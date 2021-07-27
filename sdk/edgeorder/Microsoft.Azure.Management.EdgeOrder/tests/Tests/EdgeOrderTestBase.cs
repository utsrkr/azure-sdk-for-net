using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Microsoft.Azure.Management.EdgeOrder;
using Microsoft.Azure.Management.EdgeOrder.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace EdgeOrder.Tests
{
    public class EdgeOrderTestBase : TestBase, IDisposable
    {
        protected const string SubIdKey = "SubId";
        protected const int DefaultWaitingTimeInMs = 60000;
        protected MockContext Context { get; set; }
        public EdgeOrderManagementClient Client { get; protected set; }
        public ResourceManagementClient RMClient { get; protected set; }

        public EdgeOrderTestBase(ITestOutputHelper testOutputHelper)
        {
            // Getting test method name here as we are not initializing context from each method
            var helper = (TestOutputHelper)testOutputHelper;
            ITest test = (ITest)helper.GetType().GetField("test", BindingFlags.NonPublic | BindingFlags.Instance)
                                  .GetValue(helper);
            this.Context = MockContext.Start(this.GetType(), test.TestCase.TestMethod.Method.Name);

            this.Client = this.Context.GetServiceClient<EdgeOrderManagementClient>();
            this.RMClient = this.Context.GetServiceClient<ResourceManagementClient>();

            var testEnv = TestEnvironmentFactory.GetTestEnvironment();

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                HttpMockServer.Variables[SubIdKey] = testEnv.SubscriptionId;
            }
        }

        /// <summary>
        /// Wait for the specified span unless we are in mock playback mode
        /// </summary>
        /// <param name="timeout">The span of time to wait for</param>
        public static void Wait(TimeSpan timeout)
        {
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            {
                Thread.Sleep(timeout);
            }
        }

        public void Dispose()
        {
            this.Client.Dispose();
            this.Context.Dispose();
        }

        ~EdgeOrderTestBase()
        {
            Dispose();
        }

        protected static object GetResourceManagementClient(object context, object handler)
        {
            throw new NotImplementedException();
        }

        protected static ContactDetails GetDefaultContactDetails()
        {
            return new ContactDetails("Public SDK Test", "1234567890",
                new List<string> { "testing@microsoft.com" })
            {
                PhoneExtension = "1234",
            };
        }

        protected static ShippingAddress GetDefaultShippingAddress()
        {
            return new ShippingAddress("16 TOWNSEND ST", "US")
            {
                StreetAddress2 = "Unit 1",
                City = "San Francisco",
                StateOrProvince = "CA",
                PostalCode = "94107",
                CompanyName = "Microsoft",
                AddressType = AddressType.Commercial
            };
        }

        protected static HierarchyInformation GetHierarchyInformation()
        {
            return new HierarchyInformation
            {
                ProductFamilyName = "AzureStackEdge",
                ProductLineName = "AzureStackEdge",
                ProductName = "AzureStackEdgeGPU",
                ConfigurationName = "EdgeP_Base"
            };
        }

        protected static OrderItemDetails GetDefaultOrderItemDetails()
        {
            return new OrderItemDetails(new ProductDetails(GetHierarchyInformation()), OrderItemType.Purchase)
            {
                Preferences = new Preferences
                {
                    TransportPreferences = new TransportPreferences(TransportShipmentTypes.MicrosoftManaged)
                }
            };
        }
    }
}
