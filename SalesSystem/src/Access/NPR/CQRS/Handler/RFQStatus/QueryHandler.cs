namespace NPR.CQRS.Handler.RFQStatus
{
    public class QueryHandler : IQueryHandler<GetRFQStatusQuery, List<RFQStatusGrpc>>
    {
        readonly INPRDbRepository<DbRFQStatus> _Repository;
        List<RFQStatusGrpc> _RFQStatus;

        public QueryHandler(INPRDbRepository<DbRFQStatus> repository)
        {
            _Repository = repository;
            _RFQStatus = [];
        }
        public async Task<Result<List<RFQStatusGrpc>>> Handle(GetRFQStatusQuery query, CancellationToken cancellationToken)
        {
            _RFQStatus.Clear();
            GetRFQStatusReadOnlySpec spec = new GetRFQStatusReadOnlySpec(query.Position, query.TakeAmount);
            List<DbRFQStatus> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbRFQStatus result in results)
            {
                RFQStatusGrpc rfqStatusGrpc = result.MapToRFQStatus();
                _RFQStatus.Add(rfqStatusGrpc);
            }

            return _RFQStatus;
        }
    }
}
