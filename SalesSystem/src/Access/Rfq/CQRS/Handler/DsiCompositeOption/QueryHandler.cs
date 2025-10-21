namespace Rfq.CQRS.Handler.DsiCompositeOption
{
    public class QueryHandler : IQueryHandler<GetDsiCompositeOptionQuery, List<DsiCompositeOptionGrpc>>
    {
        readonly IRfqRepository<DbDsiCompositeOption> _Repository;
        List<DsiCompositeOptionGrpc> _DsiCompositeOptionGrpc;

        public QueryHandler(IRfqRepository<DbDsiCompositeOption> repository)
        {
            _Repository = repository;
            _DsiCompositeOptionGrpc = new List<DsiCompositeOptionGrpc>();
        }

        public async Task<Result<List<DsiCompositeOptionGrpc>>> Handle(GetDsiCompositeOptionQuery query, CancellationToken cancellationToken)
        {
            _DsiCompositeOptionGrpc.Clear();
            GetDsiCompositeOptionReadOnlySpec spec = new GetDsiCompositeOptionReadOnlySpec(query.Position, query.TakeAmount);
            List<DbDsiCompositeOption> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbDsiCompositeOption result in results)
            {
              DsiCompositeOptionGrpc grpc = result.FromEntity();
                _DsiCompositeOptionGrpc.Add(grpc);
            }

            return _DsiCompositeOptionGrpc;
        }
    }
}
