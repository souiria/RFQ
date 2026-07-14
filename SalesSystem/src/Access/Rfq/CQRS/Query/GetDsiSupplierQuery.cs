namespace Rfq.CQRS.Query
{
    public class GetDsiSupplierQuery : IQuery<List<DsiSupplierGrpc>>
    {
        public int? Position 
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
