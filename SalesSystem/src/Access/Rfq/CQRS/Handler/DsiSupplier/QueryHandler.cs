namespace Rfq.CQRS.Handler.DsiSupplier
{
    public class QueryHandler : IQueryHandler<GetDsiSupplierQuery, List<DsiSupplierGrpc>>
    {
        readonly IRfqRepository<DbDsiSupplier> _Repository;
        List<DsiSupplierGrpc> _DsiSupplierGrpc;

        public QueryHandler(IRfqRepository<DbDsiSupplier> repository)
        {
            _Repository = repository;
            _DsiSupplierGrpc = new List<DsiSupplierGrpc>();
        }

        public async Task<Result<List<DsiSupplierGrpc>>> Handle(GetDsiSupplierQuery query, CancellationToken cancellationToken)
        {
            _DsiSupplierGrpc.Clear();
            GetDsiSupplierReadOnlySpec spec = new GetDsiSupplierReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiSupplier> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiSupplier result in results)
            {
                DsiSupplierGrpc grpc = result.FromEntity();
                _DsiSupplierGrpc.Add(grpc);
            }

            return _DsiSupplierGrpc;
        }
    }
}
