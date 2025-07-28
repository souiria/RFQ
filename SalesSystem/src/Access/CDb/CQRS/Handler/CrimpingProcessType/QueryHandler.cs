namespace CDb.CQRS.Handler.CrimpingProcessType
{
    sealed class QueryHandler : IQueryHandler<GetCrimpingProcessTypesQuery, List<CrimpingProcessTypeGrpc>>
    {
        readonly ICDbRepository<DbCrimpingProcessType> _Repository;
        List<CrimpingProcessTypeGrpc> _CrimpingProcessTypes;

        public QueryHandler(ICDbRepository<DbCrimpingProcessType> repository)
        {
            _Repository = repository;
            _CrimpingProcessTypes = new List<CrimpingProcessTypeGrpc>();
        }

        async Task<Result<List<CrimpingProcessTypeGrpc>>> IQueryHandler<GetCrimpingProcessTypesQuery, List<CrimpingProcessTypeGrpc>>.Handle(GetCrimpingProcessTypesQuery query, CancellationToken cancellationToken)
        {
            _CrimpingProcessTypes.Clear();
            GetCrimpingProcessTypesSpecification spec = new GetCrimpingProcessTypesSpecification(query.Position, query.TakeAmount);
            List<DbCrimpingProcessType> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbCrimpingProcessType result in results)
            {
                CrimpingProcessTypeGrpc clipTypeGrpc = result.FromEntity();
                _CrimpingProcessTypes.Add(clipTypeGrpc);
            }

            return _CrimpingProcessTypes;
        }
    }
}
