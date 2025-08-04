namespace CDb.CQRS.Handler.Component
{
    sealed class QueryHandler : IQueryHandler<GetComponentsQuery, List<CompositeComponentGrpc>>
    {
        readonly ICDbRepository<DbComponent> _Repository;
        List<CompositeComponentGrpc> _Components;

        public QueryHandler(ICDbRepository<DbComponent> repository)
        {
            _Repository = repository;
            _Components = [];
        }

        async Task<Result<List<CompositeComponentGrpc>>> IQueryHandler<GetComponentsQuery, List<CompositeComponentGrpc>>.Handle(GetComponentsQuery query, CancellationToken cancellationToken)
        {
            _Components.Clear();
            GetComponentsSpecification spec = new GetComponentsSpecification(query.Position, query.TakeAmount);
            List<DbComponent> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbComponent result in results)
            {
                CompositeComponentGrpc componentGrpc = CompositeComponentExtensions.FromEntity(result);
                _Components.Add(componentGrpc)  ;
            }

            return _Components;
        }
    }
}
