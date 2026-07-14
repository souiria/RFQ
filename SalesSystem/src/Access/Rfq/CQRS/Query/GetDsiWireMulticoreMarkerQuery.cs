namespace Rfq.CQRS.Query
{
    public class GetDsiWireMulticoreMarkerQuery : IQuery<List<DsiWireMulticoreMarkerGrpc>>
    {
        public int? Position 
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
