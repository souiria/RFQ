namespace Rfq.CQRS.Query
{
    public class GetDsiModuleCompatibilityQuery : IQuery<List<DsiModuleCompatibilityGrpc>>
    {
        public int? Position 
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
