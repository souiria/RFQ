namespace Rfq.CQRS.Handler.DsiHarnessScope
{
    public class QueryHandler : IQueryHandler<GetDsiHarnessScopeQuery, List<DsiHarnessScopeGrpc>>
    {
        readonly IRfqRepository<DbDsiHarnessScope> _Repository;
        List<DsiHarnessScopeGrpc> _DsiHarnessScopeGrpc;

        public QueryHandler(IRfqRepository<DbDsiHarnessScope> repository)
        {
            _Repository = repository;
            _DsiHarnessScopeGrpc = new List<DsiHarnessScopeGrpc>();
        }

        public async Task<Result<List<DsiHarnessScopeGrpc>>> Handle(GetDsiHarnessScopeQuery query, CancellationToken cancellationToken)
        {
            _DsiHarnessScopeGrpc.Clear();
            GetDsiHarnessScopeReadOnlySpec spec = new GetDsiHarnessScopeReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiHarnessScope> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiHarnessScope result in results)
            {
                DsiHarnessScopeGrpc grpc = result.FromEntity();
                _DsiHarnessScopeGrpc.Add(grpc);
            }

            return _DsiHarnessScopeGrpc;
        }
    }
  }
