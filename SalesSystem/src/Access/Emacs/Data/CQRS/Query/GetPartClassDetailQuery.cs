namespace Emacs.Data.CQRS.Query
{
    public class GetPartClassDetailQuery : IQuery<List<PartClassDetailGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
