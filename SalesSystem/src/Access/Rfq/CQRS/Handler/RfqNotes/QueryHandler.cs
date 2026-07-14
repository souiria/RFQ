namespace Rfq.CQRS.Handler.RfqNotes
{
    public class QueryHandler : IQueryHandler<GetRfqNotesQuery, List<RfqNotesGrpc>>
    {
        readonly IRfqRepository<DbRfqNotes> _Repository;
        List<RfqNotesGrpc> _RfqNotess;

        public QueryHandler(IRfqRepository<DbRfqNotes> repository)
        {
            _Repository = repository;
            _RfqNotess = [];
        }

        public async Task<Result<List<RfqNotesGrpc>>> Handle(GetRfqNotesQuery query, CancellationToken cancellationToken)
        {
            _RfqNotess.Clear();
            GetRfqNotesReadOnlySpec spec = new GetRfqNotesReadOnlySpec(query.Position, query.TakeAmount);
            List<DbRfqNotes> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbRfqNotes result in results)
            {
                RfqNotesGrpc rfqNotessGrpc = result.FromEntity();
                _RfqNotess.Add(rfqNotessGrpc);
            }

            return _RfqNotess;
        }
    }
}
