namespace CDb.CQRS.Handler.Masters.TermperatureRange
{
    sealed class QueryHandler : IQueryHandler<GetTemperatureRangesQuery, List<TemperatureRangeGrpc>>
    {
        readonly ICDbRepository<DbTemperatureRange> _Repository;
        List<TemperatureRangeGrpc> _TemperatureRanges;

        public QueryHandler(ICDbRepository<DbTemperatureRange> repository)
        {
            _Repository = repository;
            _TemperatureRanges = [];
        }

        async Task<Result<List<TemperatureRangeGrpc>>> IQueryHandler<GetTemperatureRangesQuery, List<TemperatureRangeGrpc>>.Handle(GetTemperatureRangesQuery query, CancellationToken cancellationToken)
        {
            _TemperatureRanges.Clear();
            GetTemperatureRangesSpecification spec = new GetTemperatureRangesSpecification(query.Position, query.TakeAmount);
            List<DbTemperatureRange> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbTemperatureRange result in results)
            {
                TemperatureRangeGrpc temperatureRangeGrpc = result.FromEntity();
                _TemperatureRanges.Add(temperatureRangeGrpc);
            }

            return _TemperatureRanges;
        }
    }
}
