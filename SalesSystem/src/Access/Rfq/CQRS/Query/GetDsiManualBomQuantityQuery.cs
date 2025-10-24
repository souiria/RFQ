namespace Rfq.CQRS.Query
{
    public class GetDsiManualBomQuantityQuery : IQuery<List<DsiManualBomQuantityGrpc>>
    {
        public int? Position 
        { get; set; }
        public int? TakeAmount 
        { get; set; }
    }
}
