namespace Rfq.CQRS.Handler.DsiScope
{
    public class QueryHandler :
        IQueryHandler<GetDsiScopeQuery, List<DsiScopeGrpc>>
    {
        readonly IRfqRepository<DbDsiScope> _Repository;

        public QueryHandler(
            IRfqRepository<DbDsiScope> repository)
        {
            _Repository = repository;
        }

        public async Task<Result<List<DsiScopeGrpc>>> Handle(
            GetDsiScopeQuery query,
            CancellationToken cancellationToken)
        {
            GetDsiScopeReadOnlySpec spec =
                new GetDsiScopeReadOnlySpec(
                    query.Position,
                    query.TakeAmount);

            List<DbDsiScope> results =
                await _Repository.ListAsync(
                    spec,
                    cancellationToken);

            List<DsiScopeGrpc> dsiScopeGrpcs =
                new List<DsiScopeGrpc>();

            foreach (DbDsiScope result in results)
            {
                DsiScopeGrpc grpc = result.FromEntity();
                dsiScopeGrpcs.Add(grpc);
            }

            return dsiScopeGrpcs;
        }
    }
}