namespace Rfq.CQRS.Query
{
    public class GetDsiUnitOfMeasureQuery : IQuery<List<DsiUnitOfMeasureGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount 
        { get; set; }
    }
}
