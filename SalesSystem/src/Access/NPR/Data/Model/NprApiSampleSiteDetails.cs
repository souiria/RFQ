namespace NPR.Data.Model
{
    public class NprApiSampleSiteDetails
    {
        /// <summary>Business Unit Code (Master)</summary>
        public string? BusinessUnitCode
        { get; set; }

        /// <summary>Sample Qty</summary>
        public int? SampleQty
        { get; set; }

        /// <summary>Username (Master)</summary>
        public string? SendSampleContactPersonName
        { get; set; }

        /// <summary>yyyy-MM-dd</summary>
        public DateTime? RequiredDate
        { get; set; }

        /// <summary>(Free Text)</summary>
        public string? FreightAccount
        { get; set; }
    }
}
