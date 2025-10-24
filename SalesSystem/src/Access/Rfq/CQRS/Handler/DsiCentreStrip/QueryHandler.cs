namespace Rfq.CQRS.Handler.DsiCentreStrip
{
    public class QueryHandler : IQueryHandler<GetDsiCentreStripQuery, List<DsiCentreStripGrpc>>
    {
        readonly IRfqRepository<DbDsiCentreStrip> _Repository;
        List<DsiCentreStripGrpc> _DsiCentreStripGrpc;

        public QueryHandler(IRfqRepository<DbDsiCentreStrip> repository)
        {
            _Repository = repository;
            _DsiCentreStripGrpc = new List<DsiCentreStripGrpc>();
        }

        public async Task<Result<List<DsiCentreStripGrpc>>> Handle(GetDsiCentreStripQuery query, CancellationToken cancellationToken)
        {
            _DsiCentreStripGrpc.Clear();
            GetDsiCentreStripReadOnlySpec spec = new GetDsiCentreStripReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiCentreStrip> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiCentreStrip result in results)
            {
                DsiCentreStripGrpc grpc = result.FromEntity();
                _DsiCentreStripGrpc.Add(grpc);
            }

            return _DsiCentreStripGrpc;
        }
    }
}
