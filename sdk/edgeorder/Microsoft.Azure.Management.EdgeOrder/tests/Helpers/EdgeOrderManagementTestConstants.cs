using System;

namespace EdgeOrder.Tests.Helpers
{
    public static class EdgeOrderManagementTestConstants
    {
        public const string DefaultResourceLocation = "eastus";
        public const string OrderingServiceRpNamespace = "Microsoft.EdgeOrder";
        public const string OrderArmIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/" +
                                               OrderingServiceRpNamespace + "/locations/{2}/orders/{3}";
    }
}