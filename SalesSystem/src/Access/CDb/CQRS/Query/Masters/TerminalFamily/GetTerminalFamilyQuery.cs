namespace CDb.CQRS.Query.Masters.TerminalFamily
{
    public class GetTerminalFamilysQuery : IQuery<List<TerminalFamilyGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
