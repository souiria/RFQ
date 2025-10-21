namespace Rfq.CQRS.Handler.DsiCompositeDetailCircuitOptionAssociation
{
    public class QueryHandler : IQueryHandler<GetDsiCompositeDetailCircuitOptionAssociationQuery, List<DsiCompositeDetailCircuitOptionAssociationGrpc>>
    {
        readonly IRfqRepository<DbDsiCompositeDetailCircuitOptionAssociation> _Repository;
        List<DsiCompositeDetailCircuitOptionAssociationGrpc> _DsiCompositeDetailCircuitOptionAssociationGrpc;

        public QueryHandler(IRfqRepository<DbDsiCompositeDetailCircuitOptionAssociation> repository)
        {
            _Repository = repository;
            _DsiCompositeDetailCircuitOptionAssociationGrpc = new List<DsiCompositeDetailCircuitOptionAssociationGrpc>();
        }

        public async Task<Result<List<DsiCompositeDetailCircuitOptionAssociationGrpc>>> Handle(GetDsiCompositeDetailCircuitOptionAssociationQuery query, CancellationToken cancellationToken)
        {
            _DsiCompositeDetailCircuitOptionAssociationGrpc.Clear();
            GetDsiCompositeDetailCircuitOptionAssociationReadOnlySpec spec = new GetDsiCompositeDetailCircuitOptionAssociationReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiCompositeDetailCircuitOptionAssociation> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiCompositeDetailCircuitOptionAssociation result in results)
            {
                  DsiCompositeDetailCircuitOptionAssociationGrpc grpc = result.FromEntity();
                _DsiCompositeDetailCircuitOptionAssociationGrpc.Add(grpc);
            }

            return _DsiCompositeDetailCircuitOptionAssociationGrpc;
        }
        }
}
