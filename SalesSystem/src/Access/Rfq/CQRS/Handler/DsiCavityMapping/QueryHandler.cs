namespace Rfq.CQRS.Handler.DsiCavityMapping
{
    public class QueryHandler : IQueryHandler<GetDsiCavityMappingQuery, List<DsiCavityMappingGrpc>>
    {
        readonly IRfqRepository<DbDsiCavityMapping> _Repository;
        List<DsiCavityMappingGrpc> _DsiCavityMappingGrpc;

        public QueryHandler(IRfqRepository<DbDsiCavityMapping> repository)
        {
            _Repository = repository;
            _DsiCavityMappingGrpc = new List<DsiCavityMappingGrpc>();
        }

        public async Task<Result<List<DsiCavityMappingGrpc>>> Handle(GetDsiCavityMappingQuery query, CancellationToken cancellationToken)
        {
            _DsiCavityMappingGrpc.Clear();
            GetDsiCavityMappingReadOnlySpec spec = new GetDsiCavityMappingReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiCavityMapping> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiCavityMapping result in results)
            {
                DsiCavityMappingGrpc dsiCavityMapping = result.FromEntity();
                _DsiCavityMappingGrpc.Add(dsiCavityMapping);
            }

            return _DsiCavityMappingGrpc;
        }
    }
}
