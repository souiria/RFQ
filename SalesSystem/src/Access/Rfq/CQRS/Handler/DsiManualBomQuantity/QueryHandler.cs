namespace Rfq.CQRS.Handler.DsiManualBomQuantity
{
    public class QueryHandler : IQueryHandler<GetDsiManualBomQuantityQuery, List<DsiManualBomQuantityGrpc>>
    {
        readonly IRfqRepository<DbDsiManualBomQuantity> _Repository;
        List<DsiManualBomQuantityGrpc> _DsiManualBomQuantityGrpc;

        public QueryHandler(IRfqRepository<DbDsiManualBomQuantity> repository)
        {
            _Repository = repository;
            _DsiManualBomQuantityGrpc = new List<DsiManualBomQuantityGrpc>();
        }

        public async Task<Result<List<DsiManualBomQuantityGrpc>>> Handle(GetDsiManualBomQuantityQuery query, CancellationToken cancellationToken)
        {
            _DsiManualBomQuantityGrpc.Clear();
            GetDsiManualBomQuantityReadOnlySpec spec = new GetDsiManualBomQuantityReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiManualBomQuantity> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiManualBomQuantity result in results)
            {
                DsiManualBomQuantityGrpc grpc = result.FromEntity();
                _DsiManualBomQuantityGrpc.Add(grpc);
            }

            return _DsiManualBomQuantityGrpc;
        }
    }
}
