namespace Edi.Unit4DataValidator.Access.Data.Models;
internal class DbEdiCustomerParameter : IAggregateRoot
{
    public Guid Id { get; set; }
    public string Customer { get; set; }
    public string CustomerLocation { get; set; }
    public string FinanceCode { get; set; }
    public string Unit4TaxCode { get; set; }
    public bool IsAutomatingInvoices { get; set; }
    public bool IsUsingCustomerDispatchNumber { get; set; }
    public bool IsUsingPartNumber { get; set; }
    public bool IsUsingH1CustomerOrderNumber { get; set; }
    public OrderIdStatus Unit4OrderIdStatus { get; set; }
    public string Unit4ProductGroup { get; set; }
    public string Unit4Warehouse { get; set; }
    public string Unit4Client { get; set; }
    public bool IsUsingH1SchedulingAgreement { get; set; }
    public Guid CustomerGuid { get; set; }
    public Guid CustomerLocationGuId { get; set; }
    public bool AllowZeroPrices { get; set; }
    public string Dim_Value_1 { get; set; }
    public string Dim_Value_2 { get; set; }
    public string Dim_Value_3 { get; set; }
    public string Dim_Value_4 { get; set; }
    public string Dim_Value_5 { get; set; }
    public string Dim_Value_6 { get; set; }
    public string Dim_Value_7 { get; set; }
    public string rel_attr_id { get; set; }
    public string rel_attr_id1 { get; set; }
    public string rel_attr_id2 { get; set; }
    public string rel_attr_id3 { get; set; }
    public string rel_attr_id4 { get; set; }
    public string rel_attr_id5 { get; set; }
    public string rel_value { get; set; }
    public string rel_value1 { get; set; }
    public string rel_value2 { get; set; }
    public string rel_value3 { get; set; }
    public string rel_value4 { get; set; }
    public string rel_value5 { get; set; }
}
