namespace Rfq.CQRS.Handler.DsiModuleCompatibility
{
    public class QueryHandler : IQueryHandler<GetDsiModuleCompatibilityQuery, List<DsiModuleCompatibilityGrpc>>
    {
        readonly IRfqRepository<DbDsiModuleCompatibility> _Repository;
        List<DsiModuleCompatibilityGrpc> _DsiModuleCompatibilityGrpc;

        public QueryHandler(IRfqRepository<DbDsiModuleCompatibility> repository)
        {
            _Repository = repository;
            _DsiModuleCompatibilityGrpc = new List<DsiModuleCompatibilityGrpc>();
        }

        public async Task<Result<List<DsiModuleCompatibilityGrpc>>> Handle(GetDsiModuleCompatibilityQuery query, CancellationToken cancellationToken)
        {
            _DsiModuleCompatibilityGrpc.Clear();
            GetDsiModuleCompatibilityReadOnlySpec spec = new GetDsiModuleCompatibilityReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiModuleCompatibility> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiModuleCompatibility result in results)
            {
                DsiModuleCompatibilityGrpc grpc = result.FromEntity();
                _DsiModuleCompatibilityGrpc.Add(grpc);
            }

            return _DsiModuleCompatibilityGrpc;
        }
    }
}
