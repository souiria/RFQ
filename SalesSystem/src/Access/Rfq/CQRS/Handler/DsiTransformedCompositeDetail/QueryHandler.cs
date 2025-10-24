namespace Rfq.CQRS.Handler.DsiTransformedCompositeDetail
{
    public class QueryHandler : IQueryHandler<GetDsiTransformedCompositeDetailQuery, List<DsiTransformedCompositeDetailGrpc>>
    {
        readonly IRfqRepository<DbDsiTransformedCompositeDetail> _Repository;
        List<DsiTransformedCompositeDetailGrpc> _DsiTransformedCompositeDetailGrpc;

        public QueryHandler(IRfqRepository<DbDsiTransformedCompositeDetail> repository)
        {
            _Repository = repository;
            _DsiTransformedCompositeDetailGrpc = new List<DsiTransformedCompositeDetailGrpc>();
        }

        public async Task<Result<List<DsiTransformedCompositeDetailGrpc>>> Handle(GetDsiTransformedCompositeDetailQuery query, CancellationToken cancellationToken)
        {
            _DsiTransformedCompositeDetailGrpc.Clear();
            GetDsiTransformedCompositeDetailReadOnlySpec spec = new GetDsiTransformedCompositeDetailReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiTransformedCompositeDetail> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiTransformedCompositeDetail result in results)
            {
                DsiTransformedCompositeDetailGrpc grpc = result.FromEntity();
                _DsiTransformedCompositeDetailGrpc.Add(grpc);
            }

            return _DsiTransformedCompositeDetailGrpc;
        }
    }
}
