
using Emacs.Data.Model;

namespace Emacs.Data.CQRS.Handler.CustomerData
{
    public class QueryHandler : IQueryHandler<GetCustomerDataQuery, List<CustomerDataDto>>
    {
        readonly IEMACSReadRepository<DbCustomerData> _Repository;
        List<CustomerDataDto> _CustomerData;

        public QueryHandler(IEMACSReadRepository<DbCustomerData> repository)
        {
            _Repository = repository;
            _CustomerData = [];
        }
        public async Task<Result<List<CustomerDataDto>>> Handle(GetCustomerDataQuery query, CancellationToken cancellationToken)
        {
            _CustomerData.Clear();
            GetCustomerDataReadOnlySpec spec = new GetCustomerDataReadOnlySpec(query.Position, query.TakeAmount);
            List<DbCustomerData> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbCustomerData result in results)
            {
                CustomerDataDto customerDataDto = result.MapToCustomerDataDto();
                _CustomerData.Add(customerDataDto);
            }

            return _CustomerData;
        }
    }
}
