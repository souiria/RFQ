namespace Rfq.CQRS.Handler.DsiPinMapping
{
    public class QueryHandler : IQueryHandler<GetDsiPinMappingQuery, List<DsiPinMappingGrpc>>
    {
        readonly IRfqRepository<DbDsiPinMapping> _Repository;
        List<DsiPinMappingGrpc> _DsiPinMappingGrpc;

        public QueryHandler(IRfqRepository<DbDsiPinMapping> repository)
        {
            _Repository = repository;
            _DsiPinMappingGrpc = new List<DsiPinMappingGrpc>();
        }

        public async Task<Result<List<DsiPinMappingGrpc>>> Handle(GetDsiPinMappingQuery query, CancellationToken cancellationToken)
        {
            _DsiPinMappingGrpc.Clear();
            GetDsiPinMappingReadOnlySpec spec = new GetDsiPinMappingReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiPinMapping> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiPinMapping result in results)
            {
                DsiPinMappingGrpc grpc = result.FromEntity();
                _DsiPinMappingGrpc.Add(grpc);
            }

            return _DsiPinMappingGrpc;
        }
    }
}
