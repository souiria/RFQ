namespace SFS.CQRS.Handler.CustomerNonWorkingDays
{
    public class QueryHandler : IQueryHandler<GetCustomerNonWorkingDaysQuery, List<CustomerNonWorkingDayViewGrpc>>
    {
        readonly ISFSReadRepository<DbCustomerNonWorkingDays> _Repository;
        List<CustomerNonWorkingDayViewGrpc> _NoWorking;

        public QueryHandler(ISFSReadRepository<DbCustomerNonWorkingDays> repository)
        {
            _Repository = repository;
            _NoWorking = [];
        }
        public async Task<Result<List<CustomerNonWorkingDayViewGrpc>>> Handle(GetCustomerNonWorkingDaysQuery query, CancellationToken cancellationToken)
        {
            _NoWorking.Clear();
            CustomerNonWorkingDayReadOnlySpec spec = new CustomerNonWorkingDayReadOnlySpec(query.Position, query.TakeAmount);
            List<DbCustomerNonWorkingDays> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbCustomerNonWorkingDays result in results)
            {
                CustomerNonWorkingDayViewGrpc customerNonworkingdaysGrpc = result.MapToCustomerNonWorkingDaysGrpc();
                _NoWorking.Add(customerNonworkingdaysGrpc);
            }

            return _NoWorking;
        }
    }
}
