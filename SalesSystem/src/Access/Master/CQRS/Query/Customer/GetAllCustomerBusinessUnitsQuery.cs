namespace Master.CQRS.Query.Customer
{
    public class GetAllCustomerBusinessUnitsQuery : IQuery<List<CustomerData>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
