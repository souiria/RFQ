namespace Rfq.CQRS.Query
{
    public class GetDsiCompositeOptionQuery : IQuery<List<DsiCompositeOptionGrpc>>
    {
        public int? Position 
        { get; set; }
        public int? TakeAmount 
        { get; set; }
    }
}
