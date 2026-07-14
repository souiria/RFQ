namespace Rfq.CQRS.Handler.RfqReason
{
    public class QueryHandler : IQueryHandler<GetRfqReasonQuery, List<RfqReasonGrpc>>
    {
        readonly IRfqRepository<DbRfqReason> _Repository;
        List<RfqReasonGrpc> _RfqReason;

        public QueryHandler(IRfqRepository<DbRfqReason> repository)
        {
            _Repository = repository;
            _RfqReason = [];
        }

        public async Task<Result<List<RfqReasonGrpc>>> Handle(GetRfqReasonQuery query, CancellationToken cancellationToken)
        {
            _RfqReason.Clear();
            GetRfqReasonReadOnlySpec spec = new GetRfqReasonReadOnlySpec(query.Position, query.TakeAmount);
            List<DbRfqReason> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbRfqReason result in results)
            {
                RfqReasonGrpc rfqReasonGrpc = result.FromEntity();
                _RfqReason.Add(rfqReasonGrpc);
            }

            return _RfqReason;
        }
    }
}
