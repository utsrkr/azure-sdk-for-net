using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace EdgeOrder.Tests.Helpers
{
    public static class EdgeOrderManagementTestUtilities
    {
        /// <summary>
        /// Determine whether the current test mode is record mode
        /// </summary>
        /// <returns></returns>
        public static bool IsRecordMode()
        {
            return HttpMockServer.Mode == HttpRecorderMode.Record;
        }

        /// <summary>
        /// Determine whether the current test mode is playback mode
        /// </summary>
        /// <returns></returns>
        public static bool IsPlaybackMode()
        {
            return HttpMockServer.Mode == HttpRecorderMode.Playback;
        }

        /// <summary>
        /// Get current subscription Id from test configurations(Environment variables).
        /// </summary>
        /// <returns></returns>
        public static string GetSubscriptionId()
        {
            string subscriptionId = null;
            if (IsRecordMode())
            {
                var environment = TestEnvironmentFactory.GetTestEnvironment();
                HttpMockServer.Variables[ConnectionStringKeys.SubscriptionIdKey] = environment.SubscriptionId;
                subscriptionId = environment.SubscriptionId;
            }
            else if (IsPlaybackMode())
            {
                subscriptionId = HttpMockServer.Variables[ConnectionStringKeys.SubscriptionIdKey];
            }

            return subscriptionId;
        }
    }
}
