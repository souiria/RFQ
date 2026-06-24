namespace DSI.CQRS.Query
{
    public class GetWireSpecificationQuery : IQuery<List<WireSpecificationGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}