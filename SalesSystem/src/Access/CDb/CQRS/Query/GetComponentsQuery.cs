namespace CDb.CQRS.Query
{
    public class GetComponentsQuery : IQuery<List<CompositeComponentGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
