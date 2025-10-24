namespace Rfq.CQRS.Query
{
    public class GetDsiTransformedModuleChildDetailQuery : IQuery<List<DsiTransformedModuleChildDetailGrpc>>
    {
        public int? Position 
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
