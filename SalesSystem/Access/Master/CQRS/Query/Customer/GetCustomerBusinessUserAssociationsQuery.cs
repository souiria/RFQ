namespace Master.CQRS.Query.Customer
{
    public class GetCustomerBusinessUserAssociationsQuery : IRequest<List<CustomerBusinessUserAssociationDto>>
    {
        public int? Position { get; set; }
        public int? TakeAmount { get; set; }
    }
}
