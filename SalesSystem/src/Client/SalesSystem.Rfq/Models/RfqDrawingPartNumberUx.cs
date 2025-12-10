using System.ComponentModel.DataAnnotations.Schema;

namespace SalesSystem.Rfq.Models
{
    public class RfqDrawingPartNumberUx
    {
        public RfqDrawingPartNumberUx()
        {
            IsCompleted = false;
            MultiMatch = false;
            MatchedPartNumbers = new List<MatchedPartNumberUx>();
        }

        public long RowId
        { get; set; }
        public long RfqId
        { get; set; }
        public string? CustomerPartNumber
        { get; set; }
        public string? DrawingPartNumber
        { get; set; }
        [Column(TypeName = "decimal(12, 5)")]
        public decimal? DrawingPartNumberPrice
        { get; set; }
        public string? SwappedPartNumber            
        { get; set; }
        [Column(TypeName = "decimal(12, 5)")]
        public decimal? SwappedPartNumberPrice
        { get; set; }
        public string? PriceSource      // JSON Material_Code & Supplier Code & System_Name
        { get; set; }
        public bool? IsExactMatch
        { get; set; }
        public bool? IsSwapped
        { get; set; }
        public string? Comments
        { get; set; }
        public bool IsCompleted
        { get; set; }
        public bool MultiMatch
        { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<Pending>")]
        public List<MatchedPartNumberUx> MatchedPartNumbers
        { get; }
    }
}

