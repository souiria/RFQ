namespace Rfq.CQRS.Handler.DsiComponent
{
    public class QueryHandler : IQueryHandler<GetDsiComponentQuery, List<DsiComponentGrpc>>
    {
        readonly IRfqRepository<DbDsiComponent> _Repository;
        List<DsiComponentGrpc> _DsiComponentGrpc;

        public QueryHandler(IRfqRepository<DbDsiComponent> repository)
        {
            _Repository = repository;
            _DsiComponentGrpc = new List<DsiComponentGrpc>();
        }

        public async Task<Result<List<DsiComponentGrpc>>> Handle(GetDsiComponentQuery query, CancellationToken cancellationToken)
        {
            _DsiComponentGrpc.Clear();
            GetDsiComponentReadOnlySpec spec = new GetDsiComponentReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiComponent> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiComponent result in results)
            {
                 DsiComponentGrpc grpc = result.FromEntity();
                _DsiComponentGrpc.Add(grpc);
            }
            
            return _DsiComponentGrpc;
        }
    }
}
