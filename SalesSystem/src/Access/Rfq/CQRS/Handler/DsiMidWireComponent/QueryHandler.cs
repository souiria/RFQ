namespace Rfq.CQRS.Handler.DsiMidWireComponent
{
    public class QueryHandler : IQueryHandler<GetDsiMidWireComponentQuery, List<DsiMidWireComponentGrpc>>
    {
        readonly IRfqRepository<DbDsiMidWireComponent> _Repository;
        List<DsiMidWireComponentGrpc> _DsiMidWireComponentGrpc;

        public QueryHandler(IRfqRepository<DbDsiMidWireComponent> repository)
        {
            _Repository = repository;
            _DsiMidWireComponentGrpc = new List<DsiMidWireComponentGrpc>();
        }

        public async Task<Result<List<DsiMidWireComponentGrpc>>> Handle(GetDsiMidWireComponentQuery query, CancellationToken cancellationToken)
        {
            _DsiMidWireComponentGrpc.Clear();
            GetDsiMidWireComponentReadOnlySpec spec = new GetDsiMidWireComponentReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiMidWireComponent> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiMidWireComponent result in results)
            {
                DsiMidWireComponentGrpc grpc = result.FromEntity();
                _DsiMidWireComponentGrpc.Add(grpc);
            }

            return _DsiMidWireComponentGrpc;
        }
    }
}
