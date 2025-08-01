using CDb.CQRS.Query.Masters.WireProtectionType;
using CDb.CQRS.Specification.Masters.WireProtectionType;

namespace CDb.CQRS.Handler.Masters.WireProtectionType
{
    sealed class QueryHandler : IQueryHandler<GetWireProtectionTypesQuery, List<WireProtectionTypeGrpc>>
    {
        readonly ICDbRepository<DbWireProtectionType> _Repository;
        List<WireProtectionTypeGrpc> _WireProtectionTypes;

        public QueryHandler(ICDbRepository<DbWireProtectionType> repository)
        {
            _Repository = repository;
            _WireProtectionTypes = [];
        }

        async Task<Result<List<WireProtectionTypeGrpc>>> IQueryHandler<GetWireProtectionTypesQuery, List<WireProtectionTypeGrpc>>.Handle(GetWireProtectionTypesQuery query, CancellationToken cancellationToken)
        {
            _WireProtectionTypes.Clear();
            GetWireProtectionTypesSpecification spec = new GetWireProtectionTypesSpecification(query.Position, query.TakeAmount);
            List<DbWireProtectionType> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbWireProtectionType result in results)
            {
                WireProtectionTypeGrpc wireProtectionTypeGrpc = result.FromEntity();
                _WireProtectionTypes.Add(wireProtectionTypeGrpc);
            }

            return _WireProtectionTypes;
        }
    }
}
