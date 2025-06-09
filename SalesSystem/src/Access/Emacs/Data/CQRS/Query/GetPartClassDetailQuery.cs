namespace Emacs.Data.CQRS.Query
{
    public class GetPartClassDetailQuery : IQuery<List<PartClassDetailDto>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
