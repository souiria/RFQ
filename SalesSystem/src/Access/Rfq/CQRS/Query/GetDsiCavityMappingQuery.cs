namespace Rfq.CQRS.Query
{
    public class GetDsiCavityMappingQuery : IQuery<List<DsiCavityMappingGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
