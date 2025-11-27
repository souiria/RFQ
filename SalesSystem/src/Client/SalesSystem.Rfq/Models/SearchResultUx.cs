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
