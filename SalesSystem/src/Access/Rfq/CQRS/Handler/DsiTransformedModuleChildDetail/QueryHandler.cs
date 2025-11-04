namespace Rfq.CQRS.Handler.DsiTransformedModuleChildDetail
{
    public class QueryHandler : IQueryHandler<GetDsiTransformedModuleChildDetailQuery, List<DsiTransformedModuleChildDetailGrpc>>
    {
        readonly IRfqRepository<DbDsiTransformedModuleChildDetail> _Repository;
        List<DsiTransformedModuleChildDetailGrpc> _DsiTransformedModuleChildDetailGrpc;

        public QueryHandler(IRfqRepository<DbDsiTransformedModuleChildDetail> repository)
        {
            _Repository = repository;
            _DsiTransformedModuleChildDetailGrpc = new List<DsiTransformedModuleChildDetailGrpc>();
        }

        public async Task<Result<List<DsiTransformedModuleChildDetailGrpc>>> Handle(GetDsiTransformedModuleChildDetailQuery query, CancellationToken cancellationToken)
        {
            _DsiTransformedModuleChildDetailGrpc.Clear();
            GetDsiTransformedModuleChildDetailReadOnlySpec spec = new GetDsiTransformedModuleChildDetailReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiTransformedModuleChildDetail> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiTransformedModuleChildDetail result in results)
            {
                DsiTransformedModuleChildDetailGrpc grpc = result.FromEntity();
                _DsiTransformedModuleChildDetailGrpc.Add(grpc);
            }

            return _DsiTransformedModuleChildDetailGrpc;
        }
    }
}
