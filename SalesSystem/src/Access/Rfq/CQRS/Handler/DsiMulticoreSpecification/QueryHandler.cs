namespace Rfq.CQRS.Handler.DsiMulticoreSpecification
{
    public class QueryHandler : IQueryHandler<GetDsiMulticoreSpecificationQuery, List<DsiMulticoreSpecificationGrpc>>
    {
        readonly IRfqRepository<DbDsiMulticoreSpecification> _Repository;
        List<DsiMulticoreSpecificationGrpc> _DsiMulticoreSpecificationGrpc;

        public QueryHandler(IRfqRepository<DbDsiMulticoreSpecification> repository)
        {
            _Repository = repository;
            _DsiMulticoreSpecificationGrpc = new List<DsiMulticoreSpecificationGrpc>();
        }

        public async Task<Result<List<DsiMulticoreSpecificationGrpc>>> Handle(GetDsiMulticoreSpecificationQuery query, CancellationToken cancellationToken)
        {
            _DsiMulticoreSpecificationGrpc.Clear();
            GetDsiMulticoreSpecificationReadOnlySpec spec = new GetDsiMulticoreSpecificationReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiMulticoreSpecification> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiMulticoreSpecification result in results)
            {
                DsiMulticoreSpecificationGrpc grpc = result.FromEntity();
                _DsiMulticoreSpecificationGrpc.Add(grpc);
            }

            return _DsiMulticoreSpecificationGrpc;
        }
    }
}
