namespace Master.CQRS.Query.Customer
{
    public class GetAllCustomerProjectAssociationsQuery : IRequest<List<CustomerProjectAssociationDto>>
    {
        public int? Position { get; set; }
        public int? TakeAmount { get; set; }
    }
}
