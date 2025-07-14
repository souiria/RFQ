namespace SFS.CQRS.Handler.Forecast
{
    public class QueryHandler : IQueryHandler<GetForecastQuery, List<ForecastViewGrpc>>
    {
        readonly ISFSReadRepository<DbForecast> _Repository;
        List<ForecastViewGrpc> _Forecast;

        public QueryHandler(ISFSReadRepository<DbForecast> repository)
        {
            _Repository = repository;
            _Forecast = [];
        }

        public async Task<Result<List<ForecastViewGrpc>>> Handle(GetForecastQuery query, CancellationToken cancellationToken)
        {
            _Forecast.Clear();

            ForecastReadOnlySpec spec = new ForecastReadOnlySpec(query.Position, query.TakeAmount);
            List<DbForecast> results = await _Repository.ListAsync(spec, cancellationToken);

            foreach (DbForecast result in results)
            {
                ForecastViewGrpc forecastData = result.MapToForecastGrpc();
                _Forecast.Add(forecastData);
            }

            return _Forecast;
        }
    }

}
