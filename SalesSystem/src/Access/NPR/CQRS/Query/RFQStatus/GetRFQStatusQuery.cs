namespace NPR.CQRS.Query.RFQStatus
{
    public class GetRFQStatusQuery : IQuery<List<RFQStatusGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
