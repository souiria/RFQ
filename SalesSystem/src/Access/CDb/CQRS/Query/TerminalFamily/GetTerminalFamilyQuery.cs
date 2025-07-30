namespace CDb.CQRS.Query.TerminalFamily
{
    public class GetTerminalFamilysQuery : IQuery<List<TerminalFamilyGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
