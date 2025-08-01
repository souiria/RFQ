using CDb.CQRS.Query.Masters.ClipType;
using CDb.CQRS.Specification.Masters.ClipType;

namespace CDb.CQRS.Handler.Masters.ClipType
{
    sealed class QueryHandler : IQueryHandler<GetClipTypesQuery, List<ClipTypeGrpc>>
    {
        readonly ICDbRepository<DbClipType> _Repository;
        List<ClipTypeGrpc> _ClipTypes;

        public QueryHandler(ICDbRepository<DbClipType> repository)
        {
            _Repository = repository;
            _ClipTypes = [];
        }

        async Task<Result<List<ClipTypeGrpc>>> IQueryHandler<GetClipTypesQuery, List<ClipTypeGrpc>>.Handle(GetClipTypesQuery query, CancellationToken cancellationToken)
        {
            _ClipTypes.Clear();
            GetClipTypesSpecification spec = new GetClipTypesSpecification(query.Position, query.TakeAmount);
            List<DbClipType> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbClipType result in results)
            {
                ClipTypeGrpc clipTypeGrpc = result.FromEntity();
                _ClipTypes.Add(clipTypeGrpc);
            }

            return _ClipTypes;
        }
    }
}
