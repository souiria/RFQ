namespace Emacs.Data.CQRS.Query
{
    public class GetSuppliersQuery : IQuery<List<SuppliersData>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
