namespace Rfq.CQRS.Query
{
    public class GetDsiScopeQuery : IQuery<List<DsiScopeGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
