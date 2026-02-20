namespace Rfq.CQRS.Handler.RfqNprRequest
{
    public class QueryHandler : IQueryHandler<GetRfqNprRequestQuery, List<RfqNprRequestGrpc>>
    {
        readonly IRfqRepository<DbRfqNprRequestModel> _Repository;
        List<RfqNprRequestGrpc> _RfqNprRequestGrpc;

        public QueryHandler(IRfqRepository<DbRfqNprRequestModel> repository)
        {
            _Repository = repository;
            _RfqNprRequestGrpc = new List<RfqNprRequestGrpc>();
        }

        public async Task<Result<List<RfqNprRequestGrpc>>> Handle(GetRfqNprRequestQuery query, CancellationToken cancellationToken)
        {
            _RfqNprRequestGrpc.Clear();
            GetRfqNprRequestReadOnlySpec spec = new GetRfqNprRequestReadOnlySpec(query.Position, query.TakeAmount);
            List<DbRfqNprRequestModel> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbRfqNprRequestModel result in results)
            {
                RfqNprRequestGrpc dsiBendGrpc = result.FromEntity();
                _RfqNprRequestGrpc.Add(dsiBendGrpc);
            }

            return _RfqNprRequestGrpc;
        }
    }
}
