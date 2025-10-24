namespace Rfq.CQRS.Query
{
    public class GetDsiPinMappingQuery : IQuery<List<DsiPinMappingGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
