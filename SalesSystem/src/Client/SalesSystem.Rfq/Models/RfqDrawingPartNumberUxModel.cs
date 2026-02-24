namespace SalesSystem.Rfq.Models
{

    public class RfqDrawingPartNumberUxModel
    {
        public RfqDrawingPartNumberUxModel()
        {
            MultiMatch = false;
            SearchResultPartNumbers = new List<RfqDrawingPartNumberUxModel>();
            Status = RfqDrawingPartNumberStatus.New;
            IsExactMatch  = false;
            IsSwapped = false;
            MultiMatch = false; 
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
        {
            get
            {
                if (IsExactMatch == true)
                {
                    return true;
                }

                // Check if drawing part number is set with a price
                bool hasDrawingPartNumberWithPrice = !string.IsNullOrWhiteSpace(DrawingPartNumber)
                    && DrawingPartNumberPrice.HasValue
                    && 0 <= DrawingPartNumberPrice;

                // Check if swapped part number is set with a swapped price
                bool hasSwappedPartNumberWithPrice = !string.IsNullOrWhiteSpace(SwappedPartNumber)
                    && SwappedPartNumberPrice.HasValue
                    && 0 <= SwappedPartNumberPrice;

                return hasDrawingPartNumberWithPrice || hasSwappedPartNumberWithPrice;
            }
        }

        public bool MultiMatch
        { get; set; }
        public int Index
        { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<Pending>")]
        public List<RfqDrawingPartNumberUxModel> SearchResultPartNumbers
        { get; }
        public PartImageDataUxModel? PartImage
        { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<Pending>")]
        public bool HasImage => PartImage != null && 0 <= PartImage.ImageBytes.Count;
        public RfqDrawingPartNumberStatus Status
        { get; set; }
    }
}

