namespace Rfq.CQRS.Handler.DsiPinMappingCavityMappingAssociation
{
    public class QueryHandler : IQueryHandler<GetDsiPinMappingCavityMappingAssociationQuery, List<DsiPinMappingCavityMappingAssociationGrpc>>
    {
        readonly IRfqRepository<DbDsiPinMappingCavityMappingAssociation> _Repository;
        List<DsiPinMappingCavityMappingAssociationGrpc> _DsiPinMappingCavityMappingAssociationGrpc;

        public QueryHandler(IRfqRepository<DbDsiPinMappingCavityMappingAssociation> repository)
        {
            _Repository = repository;
            _DsiPinMappingCavityMappingAssociationGrpc = new List<DsiPinMappingCavityMappingAssociationGrpc>();
        }

        public async Task<Result<List<DsiPinMappingCavityMappingAssociationGrpc>>> Handle(GetDsiPinMappingCavityMappingAssociationQuery query, CancellationToken cancellationToken)
        {
            _DsiPinMappingCavityMappingAssociationGrpc.Clear();
            GetDsiPinMappingCavityMappingAssociationReadOnlySpec spec = new GetDsiPinMappingCavityMappingAssociationReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiPinMappingCavityMappingAssociation> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiPinMappingCavityMappingAssociation result in results)
            {
                DsiPinMappingCavityMappingAssociationGrpc grpc = result.FromEntity();
                _DsiPinMappingCavityMappingAssociationGrpc.Add(grpc);
            }

            return _DsiPinMappingCavityMappingAssociationGrpc;
        }
    }
}
