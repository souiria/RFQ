namespace DSI.CQRS.Handler.Component
{
    public class ComponentQueryHandler : IQueryHandler<GetComponentQuery, List<ComponentGrpc>>
    {
        readonly IDSIRepository<DbComponent> _Repository;
        List<ComponentGrpc> _Result;

        public ComponentQueryHandler(IDSIRepository<DbComponent> repository)
        {
            _Repository = repository;
            _Result = new();
        }

        public async Task<Result<List<ComponentGrpc>>> Handle(GetComponentQuery query, CancellationToken cancellationToken)
        {
            _Result.Clear();

            GetComponentReadOnlySpec spec = new(query.Position, query.TakeAmount);

            List<DbComponent> data = await _Repository.ListAsync(spec, cancellationToken);

            foreach (DbComponent item in data)
            {
           
                ComponentGrpc   componentGrpc = item.FromEntity();
                _Result.Add(componentGrpc);
            }

            return _Result;
        }
    }
}
