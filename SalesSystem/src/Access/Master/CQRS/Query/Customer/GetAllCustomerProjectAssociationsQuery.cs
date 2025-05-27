namespace Master.CQRS.Query.Customer
{
    public class GetAllCustomerProjectAssociationsQuery : IQuery<List<CustomerProjectAssociationDto>>
    {
        public int? Position { get; set; }
        public int? TakeAmount { get; set; }
    }
}
