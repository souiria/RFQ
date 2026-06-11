namespace Master.CQRS.Handler.BusinessUnit
{
    sealed class QueryHandler : IQueryHandler<GetBusinessUnitsQuery, List<BusinessUnitGrpc>>
    {
        readonly IMastersReadRepository<DbBusinessUnit> _Repository;
        List<BusinessUnitGrpc> _BusinessUnits;

        public QueryHandler(IMastersReadRepository<DbBusinessUnit> repository)
        {
            _Repository = repository;
            _BusinessUnits = [];
        }

        async Task<Result<List<BusinessUnitGrpc>>> IQueryHandler<GetBusinessUnitsQuery, List<BusinessUnitGrpc>>.Handle(
            GetBusinessUnitsQuery query,
            CancellationToken cancellationToken)
        {
            _BusinessUnits.Clear();

            GetBusinessUnitsReadOnlySpec spec =
                new GetBusinessUnitsReadOnlySpec(query.Position, query.TakeAmount);

            List<DbBusinessUnit> results =
                await _Repository.ListAsync(spec, cancellationToken);

            foreach (DbBusinessUnit result in results)
            {
                BusinessUnitGrpc businessUnitGrpc = result.MapToBusinessUnitGrpc();
                _BusinessUnits.Add(businessUnitGrpc);
            }

            return _BusinessUnits;
        }
    }
}
