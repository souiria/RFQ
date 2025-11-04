namespace Rfq.CQRS.Handler.DsiHarness
{
    public class QueryHandler : IQueryHandler<GetDsiHarnessQuery, List<DsiHarnessGrpc>>
    {
        readonly IRfqRepository<DbDsiHarness> _Repository;
        List<DsiHarnessGrpc> _DsiHarnessGrpc;

        public QueryHandler(IRfqRepository<DbDsiHarness> repository)
        {
            _Repository = repository;
            _DsiHarnessGrpc = new List<DsiHarnessGrpc>();
        }

        public async Task<Result<List<DsiHarnessGrpc>>> Handle(GetDsiHarnessQuery query, CancellationToken cancellationToken)
        {
            _DsiHarnessGrpc.Clear();
            GetDsiHarnessReadOnlySpec spec = new GetDsiHarnessReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiHarness> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiHarness result in results)
            {
                DsiHarnessGrpc grpc = result.FromEntity();
                _DsiHarnessGrpc.Add(grpc);
            }

            return _DsiHarnessGrpc;
        }
    }
}
