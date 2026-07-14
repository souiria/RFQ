namespace Master.CQRS.Query.Customer
{
    public class GetCustomerBusinessUserAssociationsQuery : IQuery<List<CustomerBusinessUserAssociationGrpc>>
    {
        public Guid? UserGuid
        { get; set; }
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
