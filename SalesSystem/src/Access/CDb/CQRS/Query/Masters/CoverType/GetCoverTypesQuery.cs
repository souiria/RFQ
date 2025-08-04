namespace CDb.CQRS.Query.Masters.CoverType
{
    public class GetCoverTypesQuery : IQuery<List<CoverTypeGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
