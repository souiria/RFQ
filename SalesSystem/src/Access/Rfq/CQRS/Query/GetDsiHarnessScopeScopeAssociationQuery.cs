namespace Rfq.CQRS.Query
{
    public class GetDsiHarnessScopeScopeAssociationQuery : IQuery<List<DsiHarnessScopeScopeAssociationGrpc>>
    {
        public int? Position 
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
