namespace Rfq.CQRS.Query
{
    public class GetDsiHarnessQuery : IQuery<List<DsiHarnessGrpc>>
    {
        public int? Position 
        { get; set; }
        public int? TakeAmount 
        { get; set; }
    }
}
