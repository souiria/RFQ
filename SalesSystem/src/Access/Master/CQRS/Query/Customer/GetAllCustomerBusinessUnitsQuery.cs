namespace Master.CQRS.Query.Customer
{
    public class GetAllCustomerBusinessUnitsQuery : IQuery<List<CustomerBusinessHierarchyDto>>
    {
        public int? Position { get; set; }
        public int? TakeAmount { get; set; }
    }
}
