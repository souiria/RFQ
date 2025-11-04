namespace Rfq.CQRS.Handler.DsiWireSpecification
{
    public class QueryHandler : IQueryHandler<GetDsiWireSpecificationQuery, List<DsiWireSpecificationGrpc>>
    {
        readonly IRfqRepository<DbDsiWireSpecification> _Repository;
        List<DsiWireSpecificationGrpc> _DsiWireSpecificationGrpc;

        public QueryHandler(IRfqRepository<DbDsiWireSpecification> repository)
        {
            _Repository = repository;
            _DsiWireSpecificationGrpc = new List<DsiWireSpecificationGrpc>();
        }

        public async Task<Result<List<DsiWireSpecificationGrpc>>> Handle(GetDsiWireSpecificationQuery query, CancellationToken cancellationToken)
        {
            _DsiWireSpecificationGrpc.Clear();
            GetDsiWireSpecificationReadOnlySpec spec = new GetDsiWireSpecificationReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiWireSpecification> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiWireSpecification result in results)
            {
                DsiWireSpecificationGrpc grpc = result.FromEntity();
                _DsiWireSpecificationGrpc.Add(grpc);
            }

            return _DsiWireSpecificationGrpc;
        }
    }
}
