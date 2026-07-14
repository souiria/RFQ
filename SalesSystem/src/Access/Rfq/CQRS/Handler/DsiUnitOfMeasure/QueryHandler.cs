namespace Rfq.CQRS.Handler.DsiUnitOfMeasure
{
    public class QueryHandler : IQueryHandler<GetDsiUnitOfMeasureQuery, List<DsiUnitOfMeasureGrpc>>
    {
        readonly IRfqRepository<DbDsiUnitOfMeasure> _Repository;
        List<DsiUnitOfMeasureGrpc> _DsiUnitOfMeasureGrpc;

        public QueryHandler(IRfqRepository<DbDsiUnitOfMeasure> repository)
        {
            _Repository = repository;
            _DsiUnitOfMeasureGrpc = new List<DsiUnitOfMeasureGrpc>();
        }

        public async Task<Result<List<DsiUnitOfMeasureGrpc>>> Handle(GetDsiUnitOfMeasureQuery query, CancellationToken cancellationToken)
        {
            _DsiUnitOfMeasureGrpc.Clear();
            GetDsiUnitOfMeasureReadOnlySpec spec = new GetDsiUnitOfMeasureReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiUnitOfMeasure> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiUnitOfMeasure result in results)
            {
                DsiUnitOfMeasureGrpc grpc = result.FromEntity();
                _DsiUnitOfMeasureGrpc.Add(grpc);
            }

            return _DsiUnitOfMeasureGrpc;
        }
    }
}
