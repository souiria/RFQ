namespace Rfq.CQRS.Handler.DsiWireThroughNode
{
    public class QueryHandler : IQueryHandler<GetDsiWireThroughNodeQuery, List<DsiWireThroughNodeGrpc>>
    {
        readonly IRfqRepository<DbDsiWireThroughNode> _Repository;
        List<DsiWireThroughNodeGrpc> _DsiWireThroughNodeGrpc;

        public QueryHandler(IRfqRepository<DbDsiWireThroughNode> repository)
        {
            _Repository = repository;
            _DsiWireThroughNodeGrpc = new List<DsiWireThroughNodeGrpc>();
        }

        public async Task<Result<List<DsiWireThroughNodeGrpc>>> Handle(GetDsiWireThroughNodeQuery query, CancellationToken cancellationToken)
        {
            _DsiWireThroughNodeGrpc.Clear();
            GetDsiWireThroughNodeReadOnlySpec spec = new GetDsiWireThroughNodeReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiWireThroughNode> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiWireThroughNode result in results)
            {
                DsiWireThroughNodeGrpc grpc = result.FromEntity();
                _DsiWireThroughNodeGrpc.Add(grpc);
            }

            return _DsiWireThroughNodeGrpc;
        }
    }
}
