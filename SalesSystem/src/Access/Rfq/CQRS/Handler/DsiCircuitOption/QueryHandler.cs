namespace Rfq.CQRS.Handler.DsiCircuitOption
{
    public class QueryHandler :
        IQueryHandler<GetDsiCircuitOptionQuery, List<DsiCircuitOptionGrpc>>
    {
        readonly IRfqRepository<DbDsiCircuitOption> _Repository;

        public QueryHandler(
            IRfqRepository<DbDsiCircuitOption> repository)
        {
            _Repository = repository;
        }

        public async Task<Result<List<DsiCircuitOptionGrpc>>> Handle(
            GetDsiCircuitOptionQuery query,
            CancellationToken cancellationToken)
        {
            GetDsiCircuitOptionReadOnlySpec spec =
                new GetDsiCircuitOptionReadOnlySpec(
                    query.Position,
                    query.TakeAmount);

            List<DbDsiCircuitOption> results =
                await _Repository.ListAsync(
                    spec,
                    cancellationToken);

            List<DsiCircuitOptionGrpc> dsiCircuitOptionGrpcs =
                new List<DsiCircuitOptionGrpc>();

            foreach (DbDsiCircuitOption result in results)
            {
                DsiCircuitOptionGrpc grpc = result.FromEntity();
                dsiCircuitOptionGrpcs.Add(grpc);
            }

            return dsiCircuitOptionGrpcs;
        }
    }
}