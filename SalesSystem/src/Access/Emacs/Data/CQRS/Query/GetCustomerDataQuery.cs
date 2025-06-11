namespace Emacs.Data.CQRS.Query
{
    public class GetCustomerDataQuery : IQuery<List<CustomerDataDto>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
