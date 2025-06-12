namespace Emacs.Data.CQRS.Query
{
    public class GetNPACustomerQuery : IQuery<List<NPACustomerDto>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
