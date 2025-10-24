namespace Rfq.CQRS.Query
{
    public class GetDsiCompositeDetailQuery : IQuery<List<DsiCompositeDetailGrpc>>
    {
        public int? Position 
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
