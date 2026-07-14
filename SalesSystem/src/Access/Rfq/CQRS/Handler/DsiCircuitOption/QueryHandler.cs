namespace Rfq.CQRS.Handler.DsiCircuitOption
{
    public class QueryHandler : IQueryHandler<GetDsiCircuitOptionQuery, List<DsiCircuitOptionGrpc>>
    {
        readonly IRfqRepository<DbDsiCircuitOption> _Repository;
        List<DsiCircuitOptionGrpc> _DsiCircuitOptionGrpc;

        public QueryHandler(IRfqRepository<DbDsiCircuitOption> repository)
        {
            _Repository = repository;
            _DsiCircuitOptionGrpc = new List<DsiCircuitOptionGrpc>();
        }

        public async Task<Result<List<DsiCircuitOptionGrpc>>> Handle(GetDsiCircuitOptionQuery query, CancellationToken cancellationToken)
        {
            _DsiCircuitOptionGrpc.Clear();
            GetDsiCircuitOptionReadOnlySpec spec = new GetDsiCircuitOptionReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiCircuitOption> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiCircuitOption result in results)
            {
                DsiCircuitOptionGrpc grpc = result.FromEntity();
                _DsiCircuitOptionGrpc.Add(grpc);
            }

            return _DsiCircuitOptionGrpc;
        }
    }
}
