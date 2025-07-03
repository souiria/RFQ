namespace Emacs.CQRS.Query
{
    public class GetNPASupplierQuery : IQuery<List<NPASupplierGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
