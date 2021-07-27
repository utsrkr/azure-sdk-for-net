using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Management.EdgeOrder;
using Microsoft.Azure.Management.EdgeOrder.Models;
using System.Threading.Tasks;

namespace EdgeOrder.Tests
{
    public class ServiceOperationsTests : EdgeOrderTestBase
    {
        public ServiceOperationsTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        [Fact]
        public void TestListProductFamiliesMetadata()
        {
            var productFamiliesMetadata = this.Client.Service.ListProductFamiliesMetadata();
            Assert.True(productFamiliesMetadata != null, "List call for product families metadata was not successful.");
        }

        [Fact]
        public void TestListProductFamilies()
        {
            IList<FilterableProperty> filterableProperty = new List<FilterableProperty>()
            {
                new FilterableProperty(SupportedFilterTypes.ShipToCountries, new List<string>() { "US" })
            };
            IDictionary<string, IList<FilterableProperty>> filterableProperties =
                new Dictionary<string, IList<FilterableProperty>>() { { "azurestackedge", filterableProperty } };
            ProductFamiliesRequest productFamiliesRequest = new ProductFamiliesRequest(filterableProperties);
            var productFamilies = this.Client.Service.ListProductFamilies(productFamiliesRequest, "configurations");

            Assert.True(productFamilies != null, "List call for product families was not successful.");
        }

        [Fact]
        public void TestListConfigurations()
        {
            IList<FilterableProperty> filterableProperties = new List<FilterableProperty>();
            ConfigurationFilters configurationFilters = new ConfigurationFilters(GetHierarchyInformation(), filterableProperties);
            configurationFilters.FilterableProperty.Add(new FilterableProperty(SupportedFilterTypes.ShipToCountries,
                new List<string>() { "US" }));
            ConfigurationsRequest configurationsRequest = new ConfigurationsRequest(
                new List<ConfigurationFilters>() { configurationFilters });
            var configurations = this.Client.Service.ListConfigurations(configurationsRequest);

            Assert.True(configurations != null, "List call for configurations was not successful.");
        }
    }
}
