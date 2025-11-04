namespace Rfq.CQRS.Query
{
    public class GetDsiCompositeDetailCircuitOptionAssociationQuery : IQuery<List<DsiCompositeDetailCircuitOptionAssociationGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
