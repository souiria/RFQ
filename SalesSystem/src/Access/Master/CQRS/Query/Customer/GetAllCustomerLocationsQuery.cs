namespace Master.CQRS.Query.Customer
{
    public class GetAllCustomerLocationsQuery : IQuery<List<CustomerLocationData>>
    {
        public int? Position 
        { get; set; }
        public int? TakeAmount 
        { get; set; }
    }
}
