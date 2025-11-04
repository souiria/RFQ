namespace Rfq.CQRS.Query
{
    public class GetDsiBranchConfigurationBendAssociationQuery : IQuery<List<DsiBranchConfigurationBendAssociationGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
