using CDb.CQRS.Query.Masters.WaterproofType;
using CDb.CQRS.Specification.Masters.WaterproofType;

namespace CDb.CQRS.Handler.Masters.WaterproofType
{
    sealed class QueryHandler : IQueryHandler<GetWaterproofTypesQuery, List<WaterproofTypeGrpc>>
    {
        readonly ICDbRepository<DbWaterproofType> _Repository;
        List<WaterproofTypeGrpc> _WaterproofTypes;

        public QueryHandler(ICDbRepository<DbWaterproofType> repository)
        {
            _Repository = repository;
            _WaterproofTypes = [];
        }

        async Task<Result<List<WaterproofTypeGrpc>>> IQueryHandler<GetWaterproofTypesQuery, List<WaterproofTypeGrpc>>.Handle(GetWaterproofTypesQuery query, CancellationToken cancellationToken)
        {
            _WaterproofTypes.Clear();
            GetWaterproofTypesSpecification spec = new GetWaterproofTypesSpecification(query.Position, query.TakeAmount);
            List<DbWaterproofType> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbWaterproofType result in results)
            {
                WaterproofTypeGrpc waterproofTypeGrpc = result.FromEntity();
                _WaterproofTypes.Add(waterproofTypeGrpc);
            }

            return _WaterproofTypes;
        }
    }
}
