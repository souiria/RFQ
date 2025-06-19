namespace Emacs.Data.CQRS.Query
{
    public class GetNPASupplierQuery : IQuery<List<NPASupplierData>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
