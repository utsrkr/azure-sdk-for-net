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
    public class OrderItemCRUDTests : EdgeOrderTestBase
    {
        public OrderItemCRUDTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        [Fact]
        public void TestOrderItemCRUDOperations()
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

            // Create
            OrderItemResource orderItemResource = new OrderItemResource(EdgeOrderManagementTestConstants.DefaultResourceLocation,
                GetDefaultOrderItemDetails(), addressDetails, orderId);
            var orderItem = this.Client.OrderItems.Create(orderItemName, resourceGroupName, orderItemResource);
            Assert.True(orderItem != null, "Create call for order item was not successful");

            // Get
            var getOrderItem = this.Client.OrderItems.Get(orderItemName, resourceGroupName);
            Assert.True(getOrderItem != null, "Get call for order item was not successful");

            // Update
            addressProperties.ContactDetails.ContactName = "Updated contact name";
            OrderItemUpdateParameter orderItemUpdateParameter = new OrderItemUpdateParameter
            {
                ForwardAddress = addressProperties
            };
            var updateOrderItem = this.Client.OrderItems.Update(orderItemName, resourceGroupName, orderItemUpdateParameter);
            Assert.True(updateOrderItem != null, "Update call for order item was not successful");

            // List
            var orderItemList = this.Client.OrderItems.ListAtSubscriptionLevel();
            Assert.True(orderItemList != null, "List call for order items at subscription level was not successful");

            orderItemList = this.Client.OrderItems.ListAtResourceGroupLevel(resourceGroupName);
            Assert.True(orderItemList != null, "List call for order items at resource group level was not successful");

            //Cancel
            this.Client.OrderItems.Cancel(orderItemName, resourceGroupName,
                new CancellationReason("Order item cancelled"));
            getOrderItem = this.Client.OrderItems.Get(orderItemName, resourceGroupName);
            Assert.Equal(getOrderItem.OrderItemDetails.CurrentStage.StageName, StageName.Cancelled);
            
            // Delete
            this.Client.OrderItems.Delete(orderItemName, resourceGroupName);
        }
    }
}
