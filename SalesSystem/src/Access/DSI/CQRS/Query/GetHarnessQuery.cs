namespace DSI.CQRS.Query
{
    public class GetHarnessQuery : IQuery<List<HarnessGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
