namespace Rfq.CQRS.Query
{
    public class GetDsiMulticoreSpecificationQuery : IQuery<List<DsiMulticoreSpecificationGrpc>>
    {
        public int? Position 
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
