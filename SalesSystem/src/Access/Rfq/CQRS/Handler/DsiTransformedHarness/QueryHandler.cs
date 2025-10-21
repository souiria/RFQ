namespace Rfq.CQRS.Handler.DsiTransformedHarness
{
    public class QueryHandler : IQueryHandler<GetDsiTransformedHarnessQuery, List<DsiTransformedHarnessGrpc>>
    {
        readonly IRfqRepository<DbDsiTransformedHarness> _Repository;
        List<DsiTransformedHarnessGrpc> _DsiTransformedHarnessGrpc;

        public QueryHandler(IRfqRepository<DbDsiTransformedHarness> repository)
        {
            _Repository = repository;
            _DsiTransformedHarnessGrpc = new List<DsiTransformedHarnessGrpc>();
        }

        public async Task<Result<List<DsiTransformedHarnessGrpc>>> Handle(GetDsiTransformedHarnessQuery query, CancellationToken cancellationToken)
        {
            _DsiTransformedHarnessGrpc.Clear();
            GetDsiTransformedHarnessReadOnlySpec spec = new GetDsiTransformedHarnessReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiTransformedHarness> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiTransformedHarness result in results)
            {
                DsiTransformedHarnessGrpc grpc = result.FromEntity();
                _DsiTransformedHarnessGrpc.Add(grpc);
            }

            return _DsiTransformedHarnessGrpc;
        }
    }
}
