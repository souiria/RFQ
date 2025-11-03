namespace SalesSystem.Rfq.Models
{
    public class RfqPartNumberUx
    {
        // Move initialization to static constructor to fix IDESIGN102.
        // Remove explicit accessibility modifier to fix IDE0040.
        static readonly List<RfqPartNumberUx> _TestList;

        static RfqPartNumberUx()
        {
            _TestList = new List<RfqPartNumberUx>();
            GenerateTestData();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        static void GenerateTestData()
        {
            Random random = new Random();
            string[] partPrefixes = new[] { "ABC", "XYZ", "DEF", "GHI", "JKL", "MNO", "PQR", "STU", "VWX" };
            string[] priceSources = new[] { "Supplier A", "Supplier B", "Internal", "Market Price", "Catalog", "Quote" };
            string[] comments = new[]
            { 
                "Standard replacement", "Special order required", "Limited availability", 
                "Exact match found", "Alternative part suggested", "Price negotiable",
                "Bulk discount available", "Lead time 2 weeks", "Custom manufacturing"
            };

            // Generate 50 items with IsMatched = true
            for (int i = 1; i <= 50; i++)
            {
                decimal originalPrice = (decimal)(random.NextDouble() * 1000 + 10);
                decimal? swappedPrice = 0.3 <= random.NextDouble() ? (decimal)(originalPrice * (0.8m + (decimal)random.NextDouble() * 0.4m)) : (decimal?)null;

                RfqPartNumberUx newRfqPartNumber = new RfqPartNumberUx();
                newRfqPartNumber.RowId = i;
                newRfqPartNumber.RfqId = random.Next(1000, 9999);
                newRfqPartNumber.OriginalPartNumber = $"{partPrefixes[random.Next(partPrefixes.Length)]}-{random.Next(1000, 9999)}-{random.Next(100, 999)}";
                newRfqPartNumber.OriginalPartNumberPrice = Math.Round(originalPrice, 2);
                newRfqPartNumber.SwappedPartNumber = swappedPrice.HasValue ? $"{partPrefixes[random.Next(partPrefixes.Length)]}-{random.Next(1000, 9999)}-{random.Next(100, 999)}" : null;
                newRfqPartNumber.SwappedPartNumberPrice = swappedPrice.HasValue ? Math.Round(swappedPrice.Value, 2) : null;
                newRfqPartNumber.PriceSource = priceSources[random.Next(priceSources.Length)];
                newRfqPartNumber.IsExactMatch = 0.5 <= random.NextDouble();
                newRfqPartNumber.IsSwapped = swappedPrice.HasValue;
                newRfqPartNumber.Comments = 0.3 <= random.NextDouble() ? comments[random.Next(comments.Length)] : null;
                newRfqPartNumber.IsMatched = true;

                _TestList.Add(newRfqPartNumber);
            }

            // Generate 50 items with IsMatched = false
            for (int i = 51; i <= 100; i++)
            {
                decimal originalPrice = (decimal)(random.NextDouble() * 1000 + 10);
                bool hasSwapped = 0.7 <= random.NextDouble(); // Lower chance for unmatched items
                decimal? swappedPrice = hasSwapped ? (decimal)(originalPrice * (0.8m + (decimal)random.NextDouble() * 0.4m)) : (decimal?)null;
                
                _TestList.Add(new RfqPartNumberUx
                {
                    RowId = i,
                    RfqId = random.Next(1000, 9999),
                    OriginalPartNumber = $"{partPrefixes[random.Next(partPrefixes.Length)]}-{random.Next(1000, 9999)}-{random.Next(100, 999)}",
                    OriginalPartNumberPrice = Math.Round(originalPrice, 2),
                    SwappedPartNumber = hasSwapped ? $"{partPrefixes[random.Next(partPrefixes.Length)]}-{random.Next(1000, 9999)}-{random.Next(100, 999)}" : null,
                    SwappedPartNumberPrice = hasSwapped ? Math.Round(swappedPrice ?? 0.0m, 2) : null,
                    PriceSource = priceSources[random.Next(priceSources.Length)],
                    IsExactMatch = 0.8 <= random.NextDouble(), // Lower chance for unmatched items
                    IsSwapped = hasSwapped,
                    Comments = 0.3 <= random.NextDouble() ? comments[random.Next(comments.Length)] : null,
                    IsMatched = false
                });
            }
        }

        public static IReadOnlyList<RfqPartNumberUx> TestList => _TestList.AsReadOnly();
        public long RowId
        { get; set; }
        public long RfqId
        { get; set; }
        public string? OriginalPartNumber
        { get; set; }
        public decimal? OriginalPartNumberPrice
        { get; set; }
        public string? SwappedPartNumber            
        { get; set; }
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
        public bool? IsMatched
        { get; set; }
    }
}

