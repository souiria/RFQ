namespace SFS.CQRS.Handler.MonthlyVolumeData
{
    public class QueryHandler : IQueryHandler<GetMonthlyVolumeDataQuery, List<MonthlyVolumeDataViewGrpc>>
    {
        readonly ISFSReadRepository<DbMonthlyVolumeData> _Repository;
        List<MonthlyVolumeDataViewGrpc> _Monthly;

        public QueryHandler(ISFSReadRepository<DbMonthlyVolumeData> repository)
        {
            _Repository = repository;
            _Monthly = [];
        }

        public async Task<Result<List<MonthlyVolumeDataViewGrpc>>> Handle(GetMonthlyVolumeDataQuery query, CancellationToken cancellationToken)
        {
            _Monthly.Clear();

            MonthlyVolumeDataReadOnlySpec spec = new MonthlyVolumeDataReadOnlySpec(query.Position, query.TakeAmount);
            List<DbMonthlyVolumeData> results = await _Repository.ListAsync(spec, cancellationToken);

            foreach (DbMonthlyVolumeData result in results)
            {
                MonthlyVolumeDataViewGrpc monthlyData = result.MapToMonthlyVolumeDataGrpc();
                _Monthly.Add(monthlyData);
            }

            return _Monthly;
        }
    }
}
