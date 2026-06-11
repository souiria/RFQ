using DSI.CQRS.Query;
using DSI.CQRS.Specification;

namespace DSI.CQRS.Handler.CompositeDetail
{
    public class CompositeDetailQueryHandler : IQueryHandler<GetCompositeDetailQuery, List<CompositeDetailGrpc>>
    {
        readonly IDSIRepository<DbCompositeDetail> _Repository;
        List<CompositeDetailGrpc> _Result;

        public CompositeDetailQueryHandler(IDSIRepository<DbCompositeDetail> repository)
        {
            _Repository = repository;
            _Result = new();
        }

        public async Task<Result<List<CompositeDetailGrpc>>> Handle(GetCompositeDetailQuery query, CancellationToken cancellationToken)
        {
            _Result.Clear();

            GetCompositeDetailReadOnlySpec spec = new(query.Position, query.TakeAmount);

            List<DbCompositeDetail> data = await _Repository.ListAsync(spec, cancellationToken);

            foreach (DbCompositeDetail item in data)
            {
                CompositeDetailGrpc compositeDetailGrpc = item.FromEntity ();
                _Result.Add(compositeDetailGrpc);
            }

            return _Result;
        }
    }
}