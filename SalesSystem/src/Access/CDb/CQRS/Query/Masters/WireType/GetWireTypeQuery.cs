namespace CDb.CQRS.Query.Masters.WireType
{
    public class GetWireTypesQuery : IQuery<List<WireTypeGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
