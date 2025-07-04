namespace Emacs.CQRS.Handler.NPACustomer
{
    public class QueryHandler : IQueryHandler<GetNPACustomerQuery, List<NPACustomerGrpc>>
    {
        readonly IEMACSReadRepository<DbNPACustomer> _Repository;
        List<NPACustomerGrpc> _NPACustomer;

        public QueryHandler(IEMACSReadRepository<DbNPACustomer> repository)
        {
            _Repository = repository;
            _NPACustomer = [];
        }
        public async Task<Result<List<NPACustomerGrpc>>> Handle(GetNPACustomerQuery query, CancellationToken cancellationToken)
        {
            _NPACustomer.Clear();
            GetNPACustomerReadOnlySpec spec = new GetNPACustomerReadOnlySpec(query.Position, query.TakeAmount);
            List<DbNPACustomer> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbNPACustomer result in results)
            {
                NPACustomerGrpc nPACustomerGrpc = result.MapToNPACustomerGrpc();
                _NPACustomer.Add(nPACustomerGrpc);
            }

            return _NPACustomer;
        }
    }
}
