namespace DSI.CQRS.Handler.WireSpecification
{
    public class WireSpecificationQueryHandler : IQueryHandler<GetWireSpecificationQuery, List<WireSpecificationGrpc>>
    {
        readonly IDSIRepository<DbWireSpecification> _Repository;
        List<WireSpecificationGrpc> _Result;

        public WireSpecificationQueryHandler(IDSIRepository<DbWireSpecification> repository)
        {
            _Repository = repository;
            _Result = new();
        }

        public async Task<Result<List<WireSpecificationGrpc>>> Handle(GetWireSpecificationQuery query, CancellationToken cancellationToken)
        {
            _Result.Clear();

            GetWireSpecificationReadOnlySpec spec = new(query.Position, query.TakeAmount);

            List<DbWireSpecification> data = await _Repository.ListAsync(spec, cancellationToken);

            foreach (DbWireSpecification item in data)
            {
                WireSpecificationGrpc wireSpecificationGrpc = item.FromEntity();
                _Result.Add(wireSpecificationGrpc);
            }

            return _Result;
        }
    }
}
