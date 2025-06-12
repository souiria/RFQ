namespace Emacs.Data.CQRS.Handler.NPACustomer
{
    public class QueryHandler : IQueryHandler<GetNPACustomerQuery, List<NPACustomerDto>>
    {
        readonly IEMACSReadRepository<DbNPACustomer> _Repository;
        List<NPACustomerDto> _NPACustomer;

        public QueryHandler(IEMACSReadRepository<DbNPACustomer> repository)
        {
            _Repository = repository;
            _NPACustomer = [];
        }
        public async Task<Result<List<NPACustomerDto>>> Handle(GetNPACustomerQuery query, CancellationToken cancellationToken)
        {
            _NPACustomer.Clear();
            GetNPACustomerReadOnlySpec spec = new GetNPACustomerReadOnlySpec(query.Position, query.TakeAmount);
            List<DbNPACustomer> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbNPACustomer result in results)
            {
                NPACustomerDto nPACustomerDto = result.MapToNPACustomerDto();
                _NPACustomer.Add(nPACustomerDto);
            }

            return _NPACustomer;
        }
    }
}
