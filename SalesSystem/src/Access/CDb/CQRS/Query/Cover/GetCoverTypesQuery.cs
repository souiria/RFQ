namespace CDb.CQRS.Query.CoverType
{
    public class GetCoverTypesQuery : IQuery<List<CoverTypeGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
