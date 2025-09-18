namespace Rfq.CQRS.Handler.RfqProject
{
    public class QueryHandler : IQueryHandler<GetRfqProjectQuery, List<RfqProjectGrpc>>
    {
        readonly IRfqRepository<DbRfqProject> _Repository;
        List<RfqProjectGrpc> _RfqProject;

        public QueryHandler(IRfqRepository<DbRfqProject> repository)
        {
            _Repository = repository;
            _RfqProject = [];
        }

        public async Task<Result<List<RfqProjectGrpc>>> Handle(GetRfqProjectQuery query, CancellationToken cancellationToken)
        {
            _RfqProject.Clear();
            GetRfqProjectReadOnlySpec spec = new GetRfqProjectReadOnlySpec(query.Position, query.TakeAmount);
            List<DbRfqProject> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbRfqProject result in results)
            {
                RfqProjectGrpc rfqProjectGrpc = result.FromEntity();
                _RfqProject.Add(rfqProjectGrpc);
            }

            return _RfqProject;
        }
    }
}
