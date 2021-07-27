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
    public class AddressCRUDTests : EdgeOrderTestBase
    {
        public AddressCRUDTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        [Fact]
        public void TestAddressCRUDOperations()
        {
            var resourceGroupName = TestUtilities.GenerateName("SdkRg");
            this.RMClient.ResourceGroups.CreateOrUpdate(
                resourceGroupName,
                new ResourceGroup
                {
                    Location = EdgeOrderManagementTestConstants.DefaultResourceLocation
                });

            var addressName = TestUtilities.GenerateName("SdkAddress");
            ContactDetails contactDetails = GetDefaultContactDetails();
            ShippingAddress shippingAddress = GetDefaultShippingAddress();
            AddressResource addressResource = new AddressResource(EdgeOrderManagementTestConstants.DefaultResourceLocation, contactDetails)
            {
                ShippingAddress = shippingAddress
            };

            // Create
            var address = this.Client.Addresses.Create(addressName, resourceGroupName, addressResource);
            Assert.True(address != null, "Create call for address was not successful");

            // Get
            var getAddress = this.Client.Addresses.Get(addressName, resourceGroupName);
            Assert.True(getAddress != null, "Get call for address was not successful");

            // Update
            contactDetails.ContactName = "Updated contact name";
            AddressUpdateParameter addressUpdateParameter = new AddressUpdateParameter
            {
                ShippingAddress = shippingAddress,
                ContactDetails = contactDetails
            };
            var updateAddress = this.Client.Addresses.Update(addressName,
                resourceGroupName, addressUpdateParameter);
            Assert.True(updateAddress != null, "Update call for address was not successful");

            // List
            var addressList = this.Client.Addresses.ListAtSubscriptionLevel();
            Assert.True(addressList != null, "List call for addresses at subscription level was not successful");

            addressList = this.Client.Addresses.ListAtResourceGroupLevel(resourceGroupName);
            Assert.True(addressList != null, "List call for addresses at resource group level was not successful");

            // Delete
            this.Client.Addresses.Delete(addressName, resourceGroupName);
        }
    }
}
