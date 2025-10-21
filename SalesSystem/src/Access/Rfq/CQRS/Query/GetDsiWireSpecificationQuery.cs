namespace Rfq.CQRS.Query
{
    public class GetDsiWireSpecificationQuery : IQuery<List<DsiWireSpecificationGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
