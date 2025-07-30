namespace CDb.CQRS.Handler.WireType
{
    sealed class QueryHandler : IQueryHandler<GetWireTypesQuery, List<WireTypeGrpc>>
    {
        readonly ICDbRepository<DbWireType> _Repository;
        List<WireTypeGrpc> _WireTypes;

        public QueryHandler(ICDbRepository<DbWireType> repository)
        {
            _Repository = repository;
            _WireTypes = [];
        }

        async Task<Result<List<WireTypeGrpc>>> IQueryHandler<GetWireTypesQuery, List<WireTypeGrpc>>.Handle(GetWireTypesQuery query, CancellationToken cancellationToken)
        {
            _WireTypes.Clear();
            GetWireTypesSpecification spec = new GetWireTypesSpecification(query.Position, query.TakeAmount);
            List<DbWireType> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbWireType result in results)
            {
                WireTypeGrpc wireTypeGrpc = result.FromEntity();
                _WireTypes.Add(wireTypeGrpc);
            }

            return _WireTypes;
        }
    }
}
