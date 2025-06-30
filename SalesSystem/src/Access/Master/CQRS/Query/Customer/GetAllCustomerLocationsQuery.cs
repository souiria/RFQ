namespace Master.CQRS.Query.Customer
{
    public class GetAllCustomerLocationsQuery : IQuery<List<CustomerLocationGrpc>>
    {
        public int? Position 
        { get; set; }
        public int? TakeAmount 
        { get; set; }
    }
}
