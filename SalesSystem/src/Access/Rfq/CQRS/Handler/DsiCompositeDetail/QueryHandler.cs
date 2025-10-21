namespace Rfq.CQRS.Handler.DsiCompositeDetail
{
    public class QueryHandler : IQueryHandler<GetDsiCompositeDetailQuery, List<DsiCompositeDetailGrpc>>
    {
        readonly IRfqRepository<DbDsiCompositeDetail> _Repository;
        List<DsiCompositeDetailGrpc> _DsiCompositeDetailGrpc;

        public QueryHandler(IRfqRepository<DbDsiCompositeDetail> repository)
        {
            _Repository = repository;
            _DsiCompositeDetailGrpc = new List<DsiCompositeDetailGrpc>();
        }

        public async Task<Result<List<DsiCompositeDetailGrpc>>> Handle(GetDsiCompositeDetailQuery query, CancellationToken cancellationToken)
        {
            _DsiCompositeDetailGrpc.Clear();
            GetDsiCompositeDetailReadOnlySpec spec = new GetDsiCompositeDetailReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiCompositeDetail> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiCompositeDetail result in results)
            {
                  DsiCompositeDetailGrpc grpc = result.FromEntity();
                _DsiCompositeDetailGrpc.Add(grpc);
            }

            return _DsiCompositeDetailGrpc;
        }
    }
}
