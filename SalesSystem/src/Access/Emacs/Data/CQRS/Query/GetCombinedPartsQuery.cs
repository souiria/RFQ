namespace Emacs.Data.CQRS.Query
{
    public class GetCombinedPartsQuery : IQuery<List<CombinedPartsData>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
