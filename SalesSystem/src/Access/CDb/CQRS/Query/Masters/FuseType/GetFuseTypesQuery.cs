namespace CDb.CQRS.Query.Masters.FuseType
{
    public class GetFuseTypesQuery : IQuery<List<FuseTypeGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
