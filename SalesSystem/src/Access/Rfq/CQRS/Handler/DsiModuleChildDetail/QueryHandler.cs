namespace Rfq.CQRS.Handler.DsiModuleChildDetail
{
    public class QueryHandler : IQueryHandler<GetDsiModuleChildDetailQuery, List<DsiModuleChildDetailGrpc>>
    {
        readonly IRfqRepository<DbDsiModuleChildDetail> _Repository;
        List<DsiModuleChildDetailGrpc> _DsiModuleChildDetailGrpc;

        public QueryHandler(IRfqRepository<DbDsiModuleChildDetail> repository)
        {
            _Repository = repository;
            _DsiModuleChildDetailGrpc = new List<DsiModuleChildDetailGrpc>();
        }

        public async Task<Result<List<DsiModuleChildDetailGrpc>>> Handle(GetDsiModuleChildDetailQuery query, CancellationToken cancellationToken)
        {
            _DsiModuleChildDetailGrpc.Clear();
            GetDsiModuleChildDetailReadOnlySpec spec = new GetDsiModuleChildDetailReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiModuleChildDetail> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiModuleChildDetail result in results)
            {
                DsiModuleChildDetailGrpc grpc = result.FromEntity();
                _DsiModuleChildDetailGrpc.Add(grpc);
            }

            return _DsiModuleChildDetailGrpc;
        }
    }
}
