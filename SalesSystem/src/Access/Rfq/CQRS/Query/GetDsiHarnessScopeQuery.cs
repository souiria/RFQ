namespace Rfq.CQRS.Query
{
    public class GetDsiHarnessScopeQuery : IQuery<List<DsiHarnessScopeGrpc>>
    {
        public int? Position 
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
