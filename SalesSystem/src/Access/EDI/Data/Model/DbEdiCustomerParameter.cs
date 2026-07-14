namespace EDI.Data.Model
{
    public class DbEdiCustomerParameter : IAggregateRoot
    {
        public Guid Id
        { get; set; }
        public string? Customer
        { get; set; }
        public string? CustomerLocation
        { get; set; } 
        public string? FinanceCode
        { get; set; } 
        public string? Unit4TaxCode
        { get; set; } 
        public bool IsAutomatingInvoices
        { get; set; } 
        public bool IsUsingCustomerDispatchNumber
        { get; set; } 
        public bool IsUsingPartNumber
        { get; set; } 
        public bool IsUsingH1CustomerOrderNumber
        { get; set; } 
        public int Unit4OrderIdStatus
        { get; set; } 
        public string? Unit4ProductGroup
        { get; set; } 
        public string? Unit4Warehouse
        { get; set; } 
        public string? Unit4Client
        { get; set; } 
        public bool IsUsingH1SchedulingAgreement
        { get; set; } 
        public Guid CustomerGuid
        { get; set; } 
        public Guid CustomerLocationGuid
        { get; set; } 
        public bool AllowZeroPrices
        { get; set; } 
        public bool CriticalPathAlert
        { get; set; } 
        public string? DimValue1
        { get; set; } 
        public string? DimValue2
        { get; set; } 
        public string? DimValue3
        { get; set; } 
        public string? DimValue4
        { get; set; } 
        public string? DimValue5
        { get; set; } 
        public string? DimValue6
        { get; set; } 
        public string? DimValue7
        { get; set; } 
        public string? RelAttrId
        { get; set; } 
        public string? RelAttrId1
        { get; set; } 
        public string? RelAttrId2
        { get; set; } 
        public string? RelAttrId3
        { get; set; } 
        public string? RelAttrId4
        { get; set; } 
        public string? RelAttrId5
        { get; set; } 
        public string? RelValue
        { get; set; } 
        public string? RelValue1
        { get; set; } 
        public string? RelValue2
        { get; set; } 
        public string? RelValue3
        { get; set; } 
        public string? RelValue4
        { get; set; } 
        public string? RelValue5
        { get; set; } 
        public string? DistributionList
        { get; set; } 
    }
}
