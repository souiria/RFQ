namespace CDb.CQRS.Handler.Masters.CoverType
{
    sealed class QueryHandler : IQueryHandler<GetCoverTypesQuery, List<CoverTypeGrpc>>
    {
        readonly ICDbRepository<DbCoverType> _Repository;
        List<CoverTypeGrpc> _CoverTypes;

        public QueryHandler(ICDbRepository<DbCoverType> repository)
        {
            _Repository = repository;
            _CoverTypes = [];
        }

        async Task<Result<List<CoverTypeGrpc>>> IQueryHandler<GetCoverTypesQuery, List<CoverTypeGrpc>>.Handle(GetCoverTypesQuery query, CancellationToken cancellationToken)
        {
            _CoverTypes.Clear();
            GetCoverTypesSpecification spec = new GetCoverTypesSpecification(query.Position, query.TakeAmount);
            List<DbCoverType> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbCoverType result in results)
            {
                CoverTypeGrpc coverTypeGrpc = result.FromEntity();
                _CoverTypes.Add(coverTypeGrpc);
            }

            return _CoverTypes;
        }
    }
}
