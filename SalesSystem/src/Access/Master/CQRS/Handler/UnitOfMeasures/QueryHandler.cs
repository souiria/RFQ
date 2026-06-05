namespace Master.CQRS.Handler.UnitOfMeasure
{
    sealed class QueryHandler : IQueryHandler<GetUnitOfMeasuresQuery, List<UnitOfMeasureGrpc>>
    {
        readonly IMastersReadRepository<DbUnitOfMeasure> _Repository;
        readonly List<UnitOfMeasureGrpc> _UnitOfMeasures;

        public QueryHandler(IMastersReadRepository<DbUnitOfMeasure> repository)
        {
            _Repository = repository;
            _UnitOfMeasures = [];
        }

        async Task<Result<List<UnitOfMeasureGrpc>>> IQueryHandler<GetUnitOfMeasuresQuery, List<UnitOfMeasureGrpc>>.Handle(
            GetUnitOfMeasuresQuery query,
            CancellationToken cancellationToken)
        {
            _UnitOfMeasures.Clear();

            GetUnitOfMeasuresReadOnlySpec spec = new GetUnitOfMeasuresReadOnlySpec(
                query.Position,
                query.TakeAmount);

            List<DbUnitOfMeasure> results = await _Repository.ListAsync(spec, cancellationToken);

            foreach (DbUnitOfMeasure result in results)
            {
                UnitOfMeasureGrpc unitOfMeasureGrpc = result.MapToUnitOfMeasureGrpc();
                _UnitOfMeasures.Add(unitOfMeasureGrpc);
            }

            return _UnitOfMeasures;
        }
    }
}