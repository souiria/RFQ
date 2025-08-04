namespace CDb.CQRS.Handler.Masters.MiscellaneousComponent
{
    sealed class QueryHandler : IQueryHandler<GetMiscellaneousComponentTypesQuery, List<MiscellaneousComponentTypeGrpc>>
    {
        readonly ICDbRepository<DbMiscellaneousComponentType> _Repository;
        List<MiscellaneousComponentTypeGrpc> _MiscellaneousComponentTypes;

        public QueryHandler(ICDbRepository<DbMiscellaneousComponentType> repository)
        {
            _Repository = repository;
            _MiscellaneousComponentTypes = [];
        }

        async Task<Result<List<MiscellaneousComponentTypeGrpc>>> IQueryHandler<GetMiscellaneousComponentTypesQuery, List<MiscellaneousComponentTypeGrpc>>.Handle(GetMiscellaneousComponentTypesQuery query, CancellationToken cancellationToken)
        {
            _MiscellaneousComponentTypes.Clear();
            GetMiscellaneousComponentTypesSpecification spec = new GetMiscellaneousComponentTypesSpecification(query.Position, query.TakeAmount);
            List<DbMiscellaneousComponentType> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbMiscellaneousComponentType result in results)
            {
                MiscellaneousComponentTypeGrpc miscellaneousComponentTypeGrpc = result.FromEntity();
                _MiscellaneousComponentTypes.Add(miscellaneousComponentTypeGrpc);
            }

            return _MiscellaneousComponentTypes;
        }
    }
}
