namespace Rfq.CQRS.Query
{
    public class GetDsiTransformedCompositeDetailQuery : IQuery<List<DsiTransformedCompositeDetailGrpc>>
    {
        public int? Position 
        { get; set; }
        public int? TakeAmount 
        { get; set; }
    }
}
