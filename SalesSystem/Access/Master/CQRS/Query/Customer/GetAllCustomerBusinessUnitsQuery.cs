namespace Master.CQRS.Query.Customer
{
    public class GetAllCustomerBusinessUnitsQuery : IRequest<List<CustomerBusinessHierarchyDto>>
    {
        public int? Position { get; set; }
        public int? TakeAmount { get; set; }
    }
}
