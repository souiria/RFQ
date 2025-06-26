namespace Emacs.Data.CQRS.Handler.CustomerData
{
    public class QueryHandler : IQueryHandler<GetCustomerDataGrpcQuery, List<CustomerDataGrpc>>
    {
        readonly IEMACSReadRepository<DbCustomerData> _Repository;
        List<CustomerDataGrpc> _CustomerData;

        public QueryHandler(IEMACSReadRepository<DbCustomerData> repository)
        {
            _Repository = repository;
            _CustomerData = [];
        }
        public async Task<Result<List<CustomerDataGrpc>>> Handle(GetCustomerDataGrpcQuery query, CancellationToken cancellationToken)
        {
            _CustomerData.Clear();
            GetCustomerDataGrpcReadOnlySpec spec = new GetCustomerDataGrpcReadOnlySpec(query.Position, query.TakeAmount);
            List<DbCustomerData> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbCustomerData result in results)
            {
                CustomerDataGrpc customerDataGrpc = result.MapToCustomerDataDto();
                _CustomerData.Add(customerDataGrpc);
            }

            return _CustomerData;
        }
    }
}
