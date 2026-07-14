namespace SFS.CQRS.Handler.Customer
{
    public class QueryHandler : IQueryHandler<GetAllCustomerQuery, List<CustomerViewGrpc>>
    {
        readonly ISFSReadRepository<DbCustomer> _Repository;
        List<CustomerViewGrpc> _Customermodel;

        public QueryHandler(ISFSReadRepository<DbCustomer> repository)
        {
            _Repository = repository;
            _Customermodel = [];
        }
        public async Task<Result<List<CustomerViewGrpc>>> Handle(GetAllCustomerQuery query, CancellationToken cancellationToken)
        {
            _Customermodel.Clear();
            CustomerReadOnlySpec spec = new CustomerReadOnlySpec(query.Position, query.TakeAmount);
            List<DbCustomer> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbCustomer result in results)
            {
                CustomerViewGrpc customerGrpc = result.MapToCustomerGrpc();
                _Customermodel.Add(customerGrpc);
            }

            return _Customermodel;
        }
    }
}
