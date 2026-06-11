namespace DSI.CQRS.Handler.BranchInsulation
{
    public class BranchInsulationQueryHandler : IQueryHandler<GetBranchInsulationQuery, List<BranchInsulationGrpc>>
    {
        readonly IDSIRepository<DbBranchInsulation> _Repository;
        List<BranchInsulationGrpc> _Result;

        public BranchInsulationQueryHandler(IDSIRepository<DbBranchInsulation> repository)
        {
            _Repository = repository;
            _Result = new();
        }

        public async Task<Result<List<BranchInsulationGrpc>>> Handle(GetBranchInsulationQuery query, CancellationToken cancellationToken)
        {
            _Result.Clear();

            GetBranchInsulationReadOnlySpec spec = new(query.Position, query.TakeAmount);

            List<DbBranchInsulation> data = await _Repository.ListAsync(spec, cancellationToken);

            foreach (DbBranchInsulation item in data)
            {
                 BranchInsulationGrpc branchInsulationGrpc = item.FromEntity();
                _Result.Add(branchInsulationGrpc);

            }

            return _Result;
        }
    }
}
