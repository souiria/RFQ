namespace Rfq.CQRS.Query
{
    public class GetDsiModuleChildDetailQuery : IQuery<List<DsiModuleChildDetailGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
