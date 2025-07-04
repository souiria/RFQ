namespace CPD.Data.Models
{
    public class DbHarnessCostingCalculationDataView : IAggregateRoot
    {
        public string? Material_No
        { get; set; }
        public string? Supplier_C
        { get; set; }
        public string? Po_Unit
        { get; set; }
        public string? Issue_Unit
        { get; set; }
        public string? Bom_Unit
        { get; set; }
        public int? Unit_Confac_Po
        { get; set; }
        public int? Unit_Confac_Issue
        { get; set; }
        public decimal? Po_Price
        { get; set; }
        public string? Curr_C
        { get; set; }
        public byte? Po_Ratio
        { get; set; }
        public decimal? ExchangeRate
        { get; set; }
        public DateTime? ExchangeRate_Upd_Dt
        { get; set; }
    }
}
