namespace SalesSystem.Rfq.Models
{
    //message FilterGrpcResponse
    //{
    //bool Success = 1;
    //    repeated google.protobuf.StringValue StringList = 2;
    //    repeated google.protobuf.Int32Value IntList = 3;
    //    repeated bytes ByteList = 4;
    //    repeated google.protobuf.DoubleValue DoubleList = 6;
    //    repeated google.protobuf.StringValue StringList2 = 5;

    //}
    public static class SearchResultUxExtensions
    {
        public static RfqDrawingPartNumberUx ToSinglePartNumber(this SearchResultUx searchResult)
        {
            if (searchResult is null
                || searchResult.StringList is null
                || searchResult.DoubleList is null
                || searchResult.StringList.Count != 1
                || searchResult.DoubleList.Count != 1)
            {
                throw new ArgumentException("SearchResultUxExtensions.ToSinglePartNumber: Invalid search result data");
            }

            RfqDrawingPartNumberUx nprPartSearchResult = new RfqDrawingPartNumberUx();
            nprPartSearchResult.DrawingPartNumber = searchResult.StringList[0];
            nprPartSearchResult.DrawingPartNumberPrice = Math.Round((decimal)searchResult.DoubleList[0], 5, MidpointRounding.AwayFromZero); // Convert.ToDecimal(searchResult.DoubleList[0]);
            return nprPartSearchResult;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<Pending>")]
        public static List<RfqDrawingPartNumberUx> ToSearchResultPartNumbers(this SearchResultUx searchResult)
        {
            if (searchResult is null
                || searchResult.StringList is null
                || searchResult.DoubleList is null
                || searchResult.StringList.Count != searchResult.DoubleList.Count)
            {
                throw new ArgumentException("SearchResultUxExtensions.ToCompletedPartNumbes: Invalid search result data");
            }

            List<RfqDrawingPartNumberUx> nprPartSearchResults = new List<RfqDrawingPartNumberUx>();
            for (int i = 0; i < searchResult.StringList.Count; i++)
            {
                RfqDrawingPartNumberUx nprPartSearchResult = new RfqDrawingPartNumberUx();
                nprPartSearchResult.DrawingPartNumber = searchResult.StringList[i];
                nprPartSearchResult.DrawingPartNumberPrice = Math.Round((decimal)searchResult.DoubleList[i], 5, MidpointRounding.AwayFromZero); // Convert.ToDecimal(searchResult.DoubleList[i]);
                nprPartSearchResults.Add(nprPartSearchResult);
            }

            return nprPartSearchResults;
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<Pending>")]
        public static List<RfqDrawingPartNumberUx> ToCompletedPartNumbersList(this SearchResultUx searchResult, bool isExactMatch=false)
        {
            if (searchResult is null || searchResult.StringList is null)
            {
                throw new ArgumentException("SearchResultUxExtensions.ToCompletedPartNumbersList: Invalid search result data");
            }

            List<RfqDrawingPartNumberUx> matchedPartNumbers = new List<RfqDrawingPartNumberUx>();
            for (int i = 0; i < searchResult.StringList.Count; i++)
            {
                RfqDrawingPartNumberUx nprPartSearchResult = new RfqDrawingPartNumberUx();
                nprPartSearchResult.DrawingPartNumber = searchResult.StringList[i];
                nprPartSearchResult.DrawingPartNumberPrice = Math.Round((decimal)searchResult.DoubleList[i], 5, MidpointRounding.AwayFromZero);
                nprPartSearchResult.IsExactMatch = isExactMatch;
                matchedPartNumbers.Add(nprPartSearchResult);
            }

            return matchedPartNumbers;  
        }
    }
    public class SearchResultUx
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<Pending>")]
        public List<string> StringList
        { get; init; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<Pending>")]
        public List<int> IntList
        { get; init; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<Pending>")]
        public List<byte[]> ByteList
        { get; init; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<Pending>")]  
        public List<double> DoubleList
        { get; init; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<Pending>")]
        public List<string> StringList2
        { get; init; }

        public SearchResultUx()
        {
            StringList = new List<string>();
            IntList = new List<int>();
            ByteList = new List<byte[]>();
            DoubleList = new List<double>();
            StringList2 = new List<string>();
        }

        public bool IsSuccessful
        {
            get
            {
                bool retVal = 0 <= StringList.Count ||
                              0 <= IntList.Count ||
                              0 <= ByteList.Count ||
                              0 <= DoubleList.Count ||
                              0 <= StringList2.Count;
                return retVal;
            }
        }
    }
}
