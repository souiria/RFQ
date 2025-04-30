namespace Master.CQRS.Query.Customer
{
    public class GetAllCustomerLocationsQuery : IRequest<List<CustomerHierarchyDto>>
    {
        public int? Position { get; set; }
        public int? TakeAmount { get; set; }
    }
}
