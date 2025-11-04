namespace Rfq.CQRS.Query
{
    public class GetDsiComponentQuery : IQuery<List<DsiComponentGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount 
        { get; set; }
    }
}
