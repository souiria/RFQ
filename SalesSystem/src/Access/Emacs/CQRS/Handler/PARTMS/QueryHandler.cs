namespace Emacs.CQRS.Handler.PARTMS
{
    public class QueryHandler : IQueryHandler<GetPARTMSQuery, List<PARTMSGrpc>>
    {
        readonly IEMACSReadRepository<DbPARTMS> _Repository;
        List<PARTMSGrpc> _PARTMS;

        public QueryHandler(IEMACSReadRepository<DbPARTMS> repository)
        {
            _Repository = repository;
            _PARTMS = [];
        }
        public async Task<Result<List<PARTMSGrpc>>> Handle(GetPARTMSQuery query, CancellationToken cancellationToken)
        {
            _PARTMS.Clear();
            GetPARTMSReadOnlySpec spec = new GetPARTMSReadOnlySpec(query.Position, query.TakeAmount);
            List<DbPARTMS> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbPARTMS result in results)
            {
                PARTMSGrpc pARTMSGrpc = result.MapToPARTMSGrpc();
                _PARTMS.Add(pARTMSGrpc);
            }

            return _PARTMS;
        }
    }
}
