namespace SalesSystem.Rfq.Models
{
    //var commentData = new
    //{
    //    User = "System",
    //    Timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
    //    Action = "AutoSearch_NPR_Applied",
    //    ExactMatchPartNumbers = responseExact.StringList,
    //    ContainsMatchPartNumbers = new List<string>()
    //};
    public static class RfqDrawingPartNumberUxSearchResultExtensions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<Pending>")]
        public static List<RfqDrawingPartNumberUxModel> ToRfqDrawingPartNumberUxList(this List<string> partNumbers, bool isExactMatch = false)
        {
            List<RfqDrawingPartNumberUxModel> result = new List<RfqDrawingPartNumberUxModel>();
            foreach (string partNumber in partNumbers)
            {
                RfqDrawingPartNumberUxModel item = new RfqDrawingPartNumberUxModel();
                item.DrawingPartNumber = partNumber;
                item.IsExactMatch = isExactMatch;

                result.Add(item);
            }

            return result;
        }
    }

    public class RfqDrawingPartNumberUxSearchResult
    {
        public string? User
        { get; set; }   
        public string? Timestamp
        { get; set; }   
        public string? Action
        { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<Pending>")]
        public List<RfqDrawingPartNumberUxModel> ExactMatchPartNumbers
        { get; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<Pending>")]
        public List<RfqDrawingPartNumberUxModel> ContainsMatchPartNumbers
        { get; }
        public RfqDrawingPartNumberUxSearchResult()
        {
            ExactMatchPartNumbers = new List<RfqDrawingPartNumberUxModel>();
            ContainsMatchPartNumbers = new List<RfqDrawingPartNumberUxModel>();
        }
    }
}
