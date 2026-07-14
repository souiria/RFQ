namespace Emacs.CQRS.Query
{
    public class GetNPACustomerQuery : IQuery<List<NPACustomerGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
