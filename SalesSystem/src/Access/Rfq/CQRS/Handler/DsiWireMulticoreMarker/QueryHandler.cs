namespace Rfq.CQRS.Handler.DsiWireMulticoreMarker
{
    public class QueryHandler : IQueryHandler<GetDsiWireMulticoreMarkerQuery, List<DsiWireMulticoreMarkerGrpc>>
    {
        readonly IRfqRepository<DbDsiWireMulticoreMarker> _Repository;
        List<DsiWireMulticoreMarkerGrpc> _DsiWireMulticoreMarkerGrpc;

        public QueryHandler(IRfqRepository<DbDsiWireMulticoreMarker> repository)
        {
            _Repository = repository;
            _DsiWireMulticoreMarkerGrpc = new List<DsiWireMulticoreMarkerGrpc>();
        }

        public async Task<Result<List<DsiWireMulticoreMarkerGrpc>>> Handle(GetDsiWireMulticoreMarkerQuery query, CancellationToken cancellationToken)
        {
            _DsiWireMulticoreMarkerGrpc.Clear();
            GetDsiWireMulticoreMarkerReadOnlySpec spec = new GetDsiWireMulticoreMarkerReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiWireMulticoreMarker> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiWireMulticoreMarker result in results)
            {
                DsiWireMulticoreMarkerGrpc grpc = result.FromEntity();
                _DsiWireMulticoreMarkerGrpc.Add(grpc);
            }

            return _DsiWireMulticoreMarkerGrpc;
        }
    }
}
