namespace Emacs.Data.CQRS.Query
{
    public class GetNPACustomerQuery : IQuery<List<NPACustomerData>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
