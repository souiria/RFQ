namespace SFS.CQRS.Query.Customer
{
    public class GetAllCustomerQuery : IQuery<List<CustomerViewGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}

