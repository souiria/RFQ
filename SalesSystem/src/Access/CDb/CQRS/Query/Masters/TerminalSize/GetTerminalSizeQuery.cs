namespace CDb.CQRS.Query.Masters.TerminalSize
{
    public class GetTerminalSizesQuery : IQuery<List<TerminalSizeGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
