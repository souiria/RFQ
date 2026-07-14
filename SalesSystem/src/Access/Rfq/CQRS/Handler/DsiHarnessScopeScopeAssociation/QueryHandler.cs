namespace Rfq.CQRS.Handler.DsiHarnessScopeScopeAssociation
{
    public class QueryHandler : IQueryHandler<GetDsiHarnessScopeScopeAssociationQuery, List<DsiHarnessScopeScopeAssociationGrpc>>
    {
        readonly IRfqRepository<DbDsiHarnessScopeScopeAssociation> _Repository;
        List<DsiHarnessScopeScopeAssociationGrpc> _DsiHarnessScopeScopeAssociationGrpc;

        public QueryHandler(IRfqRepository<DbDsiHarnessScopeScopeAssociation> repository)
        {
            _Repository = repository;
            _DsiHarnessScopeScopeAssociationGrpc = new List<DsiHarnessScopeScopeAssociationGrpc>();
        }

        public async Task<Result<List<DsiHarnessScopeScopeAssociationGrpc>>> Handle(GetDsiHarnessScopeScopeAssociationQuery query, CancellationToken cancellationToken)
        {
            _DsiHarnessScopeScopeAssociationGrpc.Clear();
            GetDsiHarnessScopeScopeAssociationReadOnlySpec spec = new GetDsiHarnessScopeScopeAssociationReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiHarnessScopeScopeAssociation> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiHarnessScopeScopeAssociation result in results)
            {
                DsiHarnessScopeScopeAssociationGrpc grpc = result.FromEntity();
                _DsiHarnessScopeScopeAssociationGrpc.Add(grpc);
            }

            return _DsiHarnessScopeScopeAssociationGrpc;
        }
    }
}
