
namespace SFS.CQRS.Handler.Period
{
    public class QueryHandler : IQueryHandler<GetPeriodQuery, List<PeriodViewGrpc>>
    {
        readonly ISFSReadRepository<DbPeriod> _Repository;
        List<PeriodViewGrpc> _Period;

        public QueryHandler(ISFSReadRepository<DbPeriod> repository)
        {
            _Repository = repository;
            _Period = [];
        }

        public async Task<Result<List<PeriodViewGrpc>>> Handle(GetPeriodQuery query, CancellationToken cancellationToken)
        {
            _Period.Clear();

            PeriodReadOnlySpec spec = new PeriodReadOnlySpec(query.Position, query.TakeAmount);
            List<DbPeriod> results = await _Repository.ListAsync(spec, cancellationToken);

            foreach (DbPeriod result in results)
            {
                PeriodViewGrpc periodData = result.MapToPeriodGrpc();
                _Period.Add(periodData);
            }

            return _Period;
        }
    }
}
