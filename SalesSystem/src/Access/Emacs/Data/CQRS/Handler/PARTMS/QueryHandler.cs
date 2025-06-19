namespace Emacs.Data.CQRS.Handler.PARTMS
{
    public class QueryHandler : IQueryHandler<GetPARTMSQuery, List<PARTMSData>>
    {
        readonly IEMACSReadRepository<DbPARTMS> _Repository;
        List<PARTMSData> _PARTMS;

        public QueryHandler(IEMACSReadRepository<DbPARTMS> repository)
        {
            _Repository = repository;
            _PARTMS = [];
        }
        public async Task<Result<List<PARTMSData>>> Handle(GetPARTMSQuery query, CancellationToken cancellationToken)
        {
            _PARTMS.Clear();
            GetPARTMSReadOnlySpec spec = new GetPARTMSReadOnlySpec(query.Position, query.TakeAmount);
            List<DbPARTMS> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbPARTMS result in results)
            {
                PARTMSData pARTMSData = result.MapToPARTMSData();
                _PARTMS.Add(pARTMSData);
            }

            return _PARTMS;
        }
    }
}
