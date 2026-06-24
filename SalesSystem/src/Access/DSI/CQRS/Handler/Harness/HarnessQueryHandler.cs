namespace DSI.CQRS.Handler.Harness
{
    public class HarnessQueryHandler : IQueryHandler<GetHarnessQuery, List<HarnessGrpc>>
    {
        readonly IDSIRepository<DbHarness> _Repository;
        List<HarnessGrpc> _Result;

        public HarnessQueryHandler(IDSIRepository<DbHarness> repository)
        {
            _Repository = repository;
            _Result = new();
        }

        public async Task<Result<List<HarnessGrpc>>> Handle(GetHarnessQuery query, CancellationToken cancellationToken)
        {
            _Result.Clear();

            GetHarnessReadOnlySpec spec = new(query.Position, query.TakeAmount);

            List<DbHarness> data = await _Repository.ListAsync(spec, cancellationToken);

            foreach (DbHarness item in data)
            {
                HarnessGrpc harnessGrpc = item.FromEntity();
                _Result.Add(harnessGrpc);
            }

            return _Result;
        }
    }
}
