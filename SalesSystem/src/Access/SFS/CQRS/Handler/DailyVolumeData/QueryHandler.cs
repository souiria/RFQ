
namespace SFS.CQRS.Handler.DailyVolumeData
{
    public class QueryHandler : IQueryHandler<GetDailyVolumeDataQuery, List<DailyVolumeDataViewGrpc>>
    {
        readonly ISFSReadRepository<DbDailyVolumeData> _Repository;
        List<DailyVolumeDataViewGrpc> _Daily;

        public QueryHandler(ISFSReadRepository<DbDailyVolumeData> repository)
        {
            _Repository = repository;
            _Daily = [];
        }

        public async Task<Result<List<DailyVolumeDataViewGrpc>>> Handle(GetDailyVolumeDataQuery query, CancellationToken cancellationToken)
        {
            _Daily.Clear();

            DailyVolumeDataReadonlySpec spec = new DailyVolumeDataReadonlySpec(query.Position, query.TakeAmount);
            List<DbDailyVolumeData> results = await _Repository.ListAsync(spec, cancellationToken);

            foreach (DbDailyVolumeData result in results)
            {
                DailyVolumeDataViewGrpc dailyData = result.MapToDailyVolumeDataGrpc();
                _Daily.Add(dailyData);
            }

            return _Daily;
        }
    }
 }
