namespace Emacs.Data.CQRS.Handler.NPACustomer
{
    public class QueryHandler : IQueryHandler<GetNPACustomerQuery, List<NPACustomerData>>
    {
        readonly IEMACSReadRepository<DbNPACustomer> _Repository;
        List<NPACustomerData> _NPACustomer;

        public QueryHandler(IEMACSReadRepository<DbNPACustomer> repository)
        {
            _Repository = repository;
            _NPACustomer = [];
        }
        public async Task<Result<List<NPACustomerData>>> Handle(GetNPACustomerQuery query, CancellationToken cancellationToken)
        {
            _NPACustomer.Clear();
            GetNPACustomerReadOnlySpec spec = new GetNPACustomerReadOnlySpec(query.Position, query.TakeAmount);
            List<DbNPACustomer> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbNPACustomer result in results)
            {
                NPACustomerData nPACustomerData = result.MapToNPACustomerData();
                _NPACustomer.Add(nPACustomerData);
            }

            return _NPACustomer;
        }
    }
}
