namespace CDb.CQRS.Handler.Masters.FuseType
{
    sealed class QueryHandler : IQueryHandler<GetFuseTypesQuery, List<FuseTypeGrpc>>
    {
        readonly ICDbRepository<DbFuseType> _Repository;
        List<FuseTypeGrpc> _FuseTypes;

        public QueryHandler(ICDbRepository<DbFuseType> repository)
        {
            _Repository = repository;
            _FuseTypes = [];
        }

        async Task<Result<List<FuseTypeGrpc>>> IQueryHandler<GetFuseTypesQuery, List<FuseTypeGrpc>>.Handle(GetFuseTypesQuery query, CancellationToken cancellationToken)
        {
            _FuseTypes.Clear();
            GetFuseTypesSpecification spec = new GetFuseTypesSpecification(query.Position, query.TakeAmount);
            List<DbFuseType> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbFuseType result in results)
            {
                FuseTypeGrpc fuseTypeGrpc = result.FromEntity();
                _FuseTypes.Add(fuseTypeGrpc);
            }

            return _FuseTypes;
        }
    }
}
