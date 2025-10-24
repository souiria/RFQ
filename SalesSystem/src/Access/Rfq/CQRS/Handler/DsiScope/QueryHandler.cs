namespace Rfq.CQRS.Handler.DsiScope
{
    public class QueryHandler : IQueryHandler<GetDsiScopeQuery, List<DsiScopeGrpc>>
    {
        readonly IRfqRepository<DbDsiScope> _Repository;
        List<DsiScopeGrpc> _DsiScopeGrpc;

        public QueryHandler(IRfqRepository<DbDsiScope> repository)
        {
            _Repository = repository;
            _DsiScopeGrpc = new List<DsiScopeGrpc>();
        }

        public async Task<Result<List<DsiScopeGrpc>>> Handle(GetDsiScopeQuery query, CancellationToken cancellationToken)
        {
            _DsiScopeGrpc.Clear();
            GetDsiScopeReadOnlySpec spec = new GetDsiScopeReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiScope> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiScope result in results)
            {
                DsiScopeGrpc grpc = result.FromEntity();
                _DsiScopeGrpc.Add(grpc);
            }

            return _DsiScopeGrpc;
        }
    }
}
