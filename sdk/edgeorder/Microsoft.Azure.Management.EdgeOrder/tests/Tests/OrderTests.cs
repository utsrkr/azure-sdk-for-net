using EdgeOrder.Tests.Helpers;
using Microsoft.Azure.Management.EdgeOrder;
using Microsoft.Azure.Management.EdgeOrder.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using Xunit.Abstractions;

namespace EdgeOrder.Tests
{
    public class OrderTests : EdgeOrderTestBase
    {
        public OrderTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        [Fact]
        public void TestGetAndListOrders()
        {
            var resourceGroupName = TestUtilities.GenerateName("SdkRg");
            this.RMClient.ResourceGroups.CreateOrUpdate(
                resourceGroupName,
                new ResourceGroup
                {
                    Location = EdgeOrderManagementTestConstants.DefaultResourceLocation
                });

            var orderItemName = TestUtilities.GenerateName("SdkOrderItem");
            ContactDetails contactDetails = GetDefaultContactDetails();
            ShippingAddress shippingAddress = GetDefaultShippingAddress();
            AddressProperties addressProperties = new AddressProperties(contactDetails)
            {
                ShippingAddress = shippingAddress
            };
            AddressDetails addressDetails = new AddressDetails(addressProperties);
            string orderId = string.Format(EdgeOrderManagementTestConstants.OrderArmIdFormat,
                EdgeOrderManagementTestUtilities.GetSubscriptionId(), resourceGroupName, EdgeOrderManagementTestConstants.DefaultResourceLocation, orderItemName);

            // Create order item
            OrderItemResource orderItemResource = new OrderItemResource(EdgeOrderManagementTestConstants.DefaultResourceLocation,
                GetDefaultOrderItemDetails(), addressDetails, orderId);
            var orderItem = this.Client.OrderItems.Create(orderItemName, resourceGroupName, orderItemResource);
            Assert.True(orderItem != null, "Create call for order item was not successful");

            // Get
            var getOrder = this.Client.Orders.Get(orderItemName, resourceGroupName, 
                EdgeOrderManagementTestConstants.DefaultResourceLocation);
            Assert.True(getOrder != null, "Get call for order was not successful");

            // List
            var orderItemList = this.Client.Orders.ListAtSubscriptionLevel();
            Assert.True(orderItemList != null, "List call for orders at subscription level was not successful");

            orderItemList = this.Client.Orders.ListAtResourceGroupLevel(resourceGroupName);
            Assert.True(orderItemList != null, "List call for orders at resource group level was not successful");

            //Cancel
            this.Client.OrderItems.Cancel(orderItemName, resourceGroupName,
                new CancellationReason("Order item cancelled"));
            var getOrderItem = this.Client.OrderItems.Get(orderItemName, resourceGroupName);
            Assert.Equal(getOrderItem.OrderItemDetails.CurrentStage.StageName, StageName.Cancelled);

            // Delete
            this.Client.OrderItems.Delete(orderItemName, resourceGroupName);
        }
    }
}
