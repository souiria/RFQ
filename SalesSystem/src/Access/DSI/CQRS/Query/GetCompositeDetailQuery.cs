namespace DSI.CQRS.Query
{
    public class GetCompositeDetailQuery : IQuery<List<CompositeDetailGrpc>>
    {
        public int? Position
        { get; set; }

        public int? TakeAmount
        { get; set; }
    }
}
