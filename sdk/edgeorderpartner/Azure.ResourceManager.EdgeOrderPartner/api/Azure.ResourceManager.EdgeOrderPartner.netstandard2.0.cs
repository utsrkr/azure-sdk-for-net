namespace Azure.ResourceManager.EdgeOrderPartner
{
    public partial class EdgeOrderPartnerAPISManageInventoryMetadataOperation : Azure.Operation<Azure.Response>
    {
        protected EdgeOrderPartnerAPISManageInventoryMetadataOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeOrderPartnerAPISManagementClient
    {
        protected EdgeOrderPartnerAPISManagementClient() { }
        public EdgeOrderPartnerAPISManagementClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.EdgeOrderPartner.EdgeOrderPartnerAPISManagementClientOptions options = null) { }
        public EdgeOrderPartnerAPISManagementClient(string subscriptionId, System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.ResourceManager.EdgeOrderPartner.EdgeOrderPartnerAPISManagementClientOptions options = null) { }
        public virtual Azure.ResourceManager.EdgeOrderPartner.EdgeOrderPartnerAPISOperations EdgeOrderPartnerAPIS { get { throw null; } }
    }
    public partial class EdgeOrderPartnerAPISManagementClientOptions : Azure.Core.ClientOptions
    {
        public EdgeOrderPartnerAPISManagementClientOptions() { }
    }
    public partial class EdgeOrderPartnerAPISOperations
    {
        protected EdgeOrderPartnerAPISOperations() { }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrderPartner.Models.Operation> ListOperationsPartner(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrderPartner.Models.Operation> ListOperationsPartnerAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ManageLink(string familyIdentifier, string location, string serialNumber, Azure.ResourceManager.EdgeOrderPartner.Models.ManageLinkRequest manageLinkRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ManageLinkAsync(string familyIdentifier, string location, string serialNumber, Azure.ResourceManager.EdgeOrderPartner.Models.ManageLinkRequest manageLinkRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeOrderPartner.Models.PartnerInventory> SearchInventories(Azure.ResourceManager.EdgeOrderPartner.Models.SearchInventoriesRequest searchInventoriesRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeOrderPartner.Models.PartnerInventory> SearchInventoriesAsync(Azure.ResourceManager.EdgeOrderPartner.Models.SearchInventoriesRequest searchInventoriesRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EdgeOrderPartner.EdgeOrderPartnerAPISManageInventoryMetadataOperation StartManageInventoryMetadata(string familyIdentifier, string location, string serialNumber, Azure.ResourceManager.EdgeOrderPartner.Models.ManageInventoryMetadataRequest manageInventoryMetadataRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.EdgeOrderPartner.EdgeOrderPartnerAPISManageInventoryMetadataOperation> StartManageInventoryMetadataAsync(string familyIdentifier, string location, string serialNumber, Azure.ResourceManager.EdgeOrderPartner.Models.ManageInventoryMetadataRequest manageInventoryMetadataRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.EdgeOrderPartner.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionType : System.IEquatable<Azure.ResourceManager.EdgeOrderPartner.Models.ActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrderPartner.Models.ActionType Internal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrderPartner.Models.ActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrderPartner.Models.ActionType left, Azure.ResourceManager.EdgeOrderPartner.Models.ActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrderPartner.Models.ActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrderPartner.Models.ActionType left, Azure.ResourceManager.EdgeOrderPartner.Models.ActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AdditionalInventoryDetails
    {
        internal AdditionalInventoryDetails() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AdditionalData { get { throw null; } }
    }
    public partial class AdditionalOrderItemDetails
    {
        internal AdditionalOrderItemDetails() { }
        public Azure.ResourceManager.EdgeOrderPartner.Models.StageDetails Status { get { throw null; } }
        public Azure.ResourceManager.EdgeOrderPartner.Models.SubscriptionDetails Subscription { get { throw null; } }
    }
    public partial class BillingDetails
    {
        internal BillingDetails() { }
        public string BillingType { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ConfigurationData
    {
        internal ConfigurationData() { }
        public string ConfigurationIdentifier { get { throw null; } }
        public string ConfigurationIdentifierOnDevice { get { throw null; } }
        public string FamilyIdentifier { get { throw null; } }
        public string ProductIdentifier { get { throw null; } }
        public string ProductLineIdentifier { get { throw null; } }
    }
    public partial class ConfigurationDetails
    {
        internal ConfigurationDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOrderPartner.Models.SpecificationDetails> Specifications { get { throw null; } }
    }
    public partial class ConfigurationOnDevice
    {
        public ConfigurationOnDevice(string configurationIdentifier) { }
        public string ConfigurationIdentifier { get { throw null; } }
    }
    public partial class InventoryAdditionalDetails
    {
        internal InventoryAdditionalDetails() { }
        public Azure.ResourceManager.EdgeOrderPartner.Models.BillingDetails Billing { get { throw null; } }
        public Azure.ResourceManager.EdgeOrderPartner.Models.ConfigurationDetails Configuration { get { throw null; } }
        public Azure.ResourceManager.EdgeOrderPartner.Models.AdditionalInventoryDetails Inventory { get { throw null; } }
        public string InventoryMetadata { get { throw null; } }
        public Azure.ResourceManager.EdgeOrderPartner.Models.AdditionalOrderItemDetails OrderItem { get { throw null; } }
    }
    public partial class InventoryData
    {
        internal InventoryData() { }
        public string Location { get { throw null; } }
        public bool? RegistrationAllowed { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class ManageInventoryMetadataRequest
    {
        public ManageInventoryMetadataRequest(string inventoryMetadata) { }
        public Azure.ResourceManager.EdgeOrderPartner.Models.ConfigurationOnDevice ConfigurationOnDevice { get { throw null; } set { } }
        public string InventoryMetadata { get { throw null; } }
    }
    public enum ManageLinkOperation
    {
        Link = 0,
        Unlink = 1,
        Relink = 2,
    }
    public partial class ManageLinkRequest
    {
        public ManageLinkRequest(string managementResourceArmId, Azure.ResourceManager.EdgeOrderPartner.Models.ManageLinkOperation operation, string tenantId) { }
        public string ManagementResourceArmId { get { throw null; } }
        public Azure.ResourceManager.EdgeOrderPartner.Models.ManageLinkOperation Operation { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class ManagementResourceData
    {
        internal ManagementResourceData() { }
        public string ArmId { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class Operation
    {
        internal Operation() { }
        public Azure.ResourceManager.EdgeOrderPartner.Models.ActionType? ActionType { get { throw null; } }
        public Azure.ResourceManager.EdgeOrderPartner.Models.OperationDisplay Display { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.EdgeOrderPartner.Models.Origin? Origin { get { throw null; } }
    }
    public partial class OperationDisplay
    {
        internal OperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class OrderItemData
    {
        internal OrderItemData() { }
        public string ArmId { get { throw null; } }
        public Azure.ResourceManager.EdgeOrderPartner.Models.OrderItemType? OrderItemType { get { throw null; } }
    }
    public enum OrderItemType
    {
        Purchase = 0,
        Rental = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Origin : System.IEquatable<Azure.ResourceManager.EdgeOrderPartner.Models.Origin>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Origin(string value) { throw null; }
        public static Azure.ResourceManager.EdgeOrderPartner.Models.Origin System { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrderPartner.Models.Origin User { get { throw null; } }
        public static Azure.ResourceManager.EdgeOrderPartner.Models.Origin UserSystem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeOrderPartner.Models.Origin other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeOrderPartner.Models.Origin left, Azure.ResourceManager.EdgeOrderPartner.Models.Origin right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeOrderPartner.Models.Origin (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeOrderPartner.Models.Origin left, Azure.ResourceManager.EdgeOrderPartner.Models.Origin right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PartnerInventory
    {
        internal PartnerInventory() { }
        public Azure.ResourceManager.EdgeOrderPartner.Models.ConfigurationData Configuration { get { throw null; } }
        public Azure.ResourceManager.EdgeOrderPartner.Models.InventoryAdditionalDetails Details { get { throw null; } }
        public Azure.ResourceManager.EdgeOrderPartner.Models.InventoryData Inventory { get { throw null; } }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.EdgeOrderPartner.Models.ManagementResourceData ManagementResource { get { throw null; } }
        public Azure.ResourceManager.EdgeOrderPartner.Models.OrderItemData OrderItem { get { throw null; } }
        public string SerialNumber { get { throw null; } }
    }
    public partial class SearchInventoriesRequest
    {
        public SearchInventoriesRequest(string serialNumber, string familyIdentifier) { }
        public string FamilyIdentifier { get { throw null; } }
        public string SerialNumber { get { throw null; } }
    }
    public partial class SpecificationDetails
    {
        internal SpecificationDetails() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class StageDetails
    {
        internal StageDetails() { }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.EdgeOrderPartner.Models.StageName? StageName { get { throw null; } }
        public Azure.ResourceManager.EdgeOrderPartner.Models.StageStatus? StageStatus { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
    }
    public enum StageName
    {
        DeviceOrdered = 0,
        DevicePrepared = 1,
        PickedUp = 2,
        AtAzureDC = 3,
        DataCopy = 4,
        Completed = 5,
        CompletedWithErrors = 6,
        Cancelled = 7,
        Aborted = 8,
        Current = 9,
        CompletedWithWarnings = 10,
        ReadyToDispatchFromAzureDC = 11,
        ReadyToReceiveAtAzureDC = 12,
        Placed = 13,
        InReview = 14,
        Confirmed = 15,
        ReadyForDispatch = 16,
        Shipped = 17,
        Delivered = 18,
        InUse = 19,
    }
    public enum StageStatus
    {
        None = 0,
        InProgress = 1,
        Succeeded = 2,
        Failed = 3,
        Cancelled = 4,
        Cancelling = 5,
    }
    public partial class SubscriptionDetails
    {
        internal SubscriptionDetails() { }
        public string Id { get { throw null; } }
        public string QuotaId { get { throw null; } }
        public string State { get { throw null; } }
    }
}
