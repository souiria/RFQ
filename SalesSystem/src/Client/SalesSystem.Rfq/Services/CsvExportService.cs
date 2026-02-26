namespace SalesSystem.Rfq.Services
{
    public class CsvExportService
    {
        readonly IJSRuntime _JsRuntime;

        public CsvExportService(IJSRuntime jsRuntime)
        {
            _JsRuntime = jsRuntime;
        }

        public async Task ExportPartNumbersToCsvAsync(
            Collection<RfqDrawingPartNumberUxModel?> matchedParts,
            Collection<RfqDrawingPartNumberUxModel?> unmatchedParts,
            string fileName = "RFQ_Parts_Export")
        {
            try
            {
                // Prepare export data
                List<RfqPartNumberExportModel> exportData = new List<RfqPartNumberExportModel>();

                // Add matched parts
                List<RfqDrawingPartNumberUxModel?> matched = matchedParts.Where(p => p != null).ToList();
                foreach (RfqDrawingPartNumberUxModel? part in matched)
                {
                    RfqPartNumberExportModel record = new RfqPartNumberExportModel();

                    record.RowId = part!.RowId;
                    record.RfqId = part.RfqId;
                    record.Category = "Matched";
                    record.OriginalPartNumber = part.DrawingPartNumber;
                    record.OriginalPartNumberPrice = part.DrawingPartNumberPrice;
                    record.SwappedPartNumber = part.SwappedPartNumber;
                    record.SwappedPartNumberPrice = part.SwappedPartNumberPrice;
                    record.PriceSource = part.PriceSource;
                    record.IsExactMatch = part.IsExactMatch;
                    record.IsSwapped = part.IsSwapped;
                    record.IsCompleted = part.IsCompleted;
                    record.MultiMatch = part.MultiMatch;
                    record.PriceDifference = part.SwappedPartNumberPrice - part.DrawingPartNumberPrice;
                    record.Comments = part.Comments;

                    exportData.Add(record);
                }

                // Add unmatched parts
                List<RfqDrawingPartNumberUxModel?> unmatched = unmatchedParts.Where(p => p != null).ToList();
                foreach (RfqDrawingPartNumberUxModel? part in unmatched)
                {
                    RfqPartNumberExportModel record = new RfqPartNumberExportModel();
                    record.RowId = part!.RowId;
                    record.RfqId = part.RfqId;
                    record.Category = "Unmatched";
                    record.OriginalPartNumber = part.DrawingPartNumber;
                    record.OriginalPartNumberPrice = part.DrawingPartNumberPrice;
                    record.SwappedPartNumber = part.SwappedPartNumber;
                    record.SwappedPartNumberPrice = part.SwappedPartNumberPrice;
                    record.PriceSource = part.PriceSource;
                    record.IsExactMatch = part.IsExactMatch;
                    record.IsSwapped = part.IsSwapped;
                    record.IsCompleted = part.IsCompleted;
                    record.MultiMatch = part.MultiMatch;
                    record.PriceDifference = part.SwappedPartNumberPrice - part.DrawingPartNumberPrice;
                    record.Comments = part.Comments;
                    exportData.Add(record);
                }

                // Sort by category (Matched first, then Unmatched) and then by RowId
                exportData = exportData
                    .OrderBy(x => x.Category == "Matched" ? 0 : 1)
                    .ThenBy(x => x.RowId)
                    .ToList();

                // Generate CSV
                string csvContent = await GenerateCsvContentAsync(exportData);

                // Trigger download
                await DownloadFileAsync(csvContent, $"{fileName}_{DateTime.Now:yyyyMMdd_HHmmss}.csv", "text/csv");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error exporting parts to CSV: {ex.Message}", ex);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "<Pending>")]
        async Task<string> GenerateCsvContentAsync(List<RfqPartNumberExportModel> data)
        {
            return await Task.Run(() =>
            {
                using StringWriter stringWriter = new StringWriter();

                CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture);
                // Excel-compatible settings
                config.HasHeaderRecord = true;
                config.TrimOptions = TrimOptions.Trim;
                config.ShouldQuote = args => true; // Quote all fields for Excel compatibility
                config.Encoding = Encoding.UTF8;

                using CsvWriter csv = new CsvWriter(stringWriter, config);

                // Write custom headers for better readability
                csv.WriteField("Row ID");
                csv.WriteField("RFQ ID");
                csv.WriteField("Category");
                csv.WriteField("Original Part Number");
                csv.WriteField("Original Price");
                csv.WriteField("Matched Part Number");
                csv.WriteField("Matched Price");
                csv.WriteField("Price Source");
                csv.WriteField("Exact Match");
                csv.WriteField("Is Swapped");
                csv.WriteField("Is Matched");
                csv.WriteField("Multi Match");
                csv.WriteField("Price Difference");
                csv.WriteField("Comments");
                csv.NextRecord();

                // Write data
                foreach (RfqPartNumberExportModel record in data)
                {
                    csv.WriteField(record.RowId);
                    csv.WriteField(record.RfqId);
                    csv.WriteField(record.Category);
                    csv.WriteField(record.OriginalPartNumber ?? "");
                    csv.WriteField(record.OriginalPartNumberPrice?.ToString("0.#####") ?? "");
                    csv.WriteField(record.SwappedPartNumber ?? "");
                    csv.WriteField(record.SwappedPartNumberPrice?.ToString("0.#####") ?? "");
                    csv.WriteField(record.PriceSource ?? "");
                    csv.WriteField(record.IsExactMatch?.ToString() ?? "");
                    csv.WriteField(record.IsSwapped?.ToString() ?? "");
                    csv.WriteField(record.IsCompleted ? "yes" : "no");
                    csv.WriteField(record.MultiMatch ? "yes" : "no" );
                    csv.WriteField(record.PriceDifference?.ToString("0.#####") ?? "");
                    csv.WriteField(record.Comments ?? "");
                    csv.NextRecord();
                }

                string r = stringWriter.ToString();
                return r;
            });
        }

        async Task DownloadFileAsync(string content, string fileName, string mimeType)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(content);
            string base64String = Convert.ToBase64String(bytes);
            
            await _JsRuntime.InvokeVoidAsync("downloadFileFromBase64", base64String, fileName, mimeType);
        }
    }
}