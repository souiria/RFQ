namespace CDb.CQRS.Query
{
    public class GetPartNumbersQuery : IQuery<List<PartNumberGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
