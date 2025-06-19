namespace Emacs.Data.CQRS.Query
{
    public class GetCustomerDataQuery : IQuery<List<CustomerDataGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
