namespace Master.CQRS.Query.Customer
{
    public class GetAllCustomerSalesEntitiesQuery : IRequest<List<CustomerSalesEntityDto>>
    {
        public int? Position { get; set; }
        public int? TakeAmount { get; set; }
    }
}
