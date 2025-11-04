namespace Rfq.CQRS.Query
{
    public class GetDsiPinMappingCavityMappingAssociationQuery : IQuery<List<DsiPinMappingCavityMappingAssociationGrpc>>
    {
        public int? Position 
        { get; set; }
        public int? TakeAmount 
        { get; set; }
    }
}
