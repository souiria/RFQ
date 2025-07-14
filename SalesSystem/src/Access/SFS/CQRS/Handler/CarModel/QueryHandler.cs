
namespace SFS.CQRS.Handler.CarModel
{
    public class QueryHandler : IQueryHandler<GetAllCarModelQuery, List<CarModelViewGrpc>>
    {
        readonly ISFSReadRepository<DbCarModel> _Repository;
        List<CarModelViewGrpc> _Carmodel;

        public QueryHandler(ISFSReadRepository<DbCarModel> repository)
        {
            _Repository = repository;
            _Carmodel = [];
        }
        public async Task<Result<List<CarModelViewGrpc>>> Handle(GetAllCarModelQuery query, CancellationToken cancellationToken)
        {
            _Carmodel.Clear();
            CarModelReadOnlySpec spec = new CarModelReadOnlySpec(query.Position, query.TakeAmount);
            List<DbCarModel> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbCarModel result in results)
            {
                CarModelViewGrpc carmodelTypeGrpc = result.MapToCarModelGrpc();
                _Carmodel.Add(carmodelTypeGrpc);
            }

            return _Carmodel;
        }
    }
}
