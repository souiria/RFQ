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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<Pending>")]
        public static List<NprSearchResult> ToNprSearchResultsList(this SearchResultUx searchResult)
        {
            if (searchResult is null
                || searchResult.StringList is null
                || searchResult.DoubleList is null
                || searchResult.StringList.Count != searchResult.DoubleList.Count)
            {
                throw new ArgumentException("SearchResultUxExtensions.ToMatchedPartNumbes: Invalid search result data");
            }

            List<NprSearchResult> nprPartSearchResults = new List<NprSearchResult>();
            for (int i = 0; i < searchResult.StringList.Count; i++)
            {
                NprSearchResult nprPartSearchResult = new NprSearchResult();
                nprPartSearchResult.SewsePartNumber = searchResult.StringList[i];
                nprPartSearchResult.Price = Math.Round((decimal)searchResult.DoubleList[i], 5, MidpointRounding.AwayFromZero); // Convert.ToDecimal(searchResult.DoubleList[i]);
                nprPartSearchResults.Add(nprPartSearchResult);
            }

            return nprPartSearchResults;
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<Pending>")]
        public static List<MatchedPartNumberUx> ToMatchedPartNumbersList(this SearchResultUx searchResult, bool isExactMatch=false)
        {
            if (searchResult is null || searchResult.StringList is null)
            {
                throw new ArgumentException("SearchResultUxExtensions.ToMatchedPartNumbersList: Invalid search result data");
            }

            List<MatchedPartNumberUx> matchedPartNumbers = new List<MatchedPartNumberUx>();
            for (int i = 0; i < searchResult.StringList.Count; i++)
            {
                MatchedPartNumberUx nprPartSearchResult = new MatchedPartNumberUx();
                nprPartSearchResult.SewsePartNumber = searchResult.StringList[i];
                nprPartSearchResult.IsExactMatch = isExactMatch;
                matchedPartNumbers.Add(nprPartSearchResult);
            }

            return matchedPartNumbers;  
        }
    }
    public class SearchResultUx
    {
        public Collection<string> StringList
        { get; init; }

        public Collection<int> IntList
        { get; init; }
        public Collection<byte[]> ByteList
        { get; init; }

        public Collection<double> DoubleList
        { get; init; }

        public Collection<string> StringList2
        { get; init; }

        public SearchResultUx()
        {
            StringList = new Collection<string>();
            IntList = new Collection<int>();
            ByteList = new Collection<byte[]>();
            DoubleList = new Collection<double>();
            StringList2 = new Collection<string>();
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
