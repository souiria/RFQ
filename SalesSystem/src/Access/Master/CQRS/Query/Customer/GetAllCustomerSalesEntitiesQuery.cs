namespace Master.CQRS.Query.Customer
{
    public class GetAllCustomerSalesEntitiesQuery : IQuery<List<CustomerSalesEntityDto>>
    {
        public int? Position { get; set; }
        public int? TakeAmount { get; set; }
    }
}
