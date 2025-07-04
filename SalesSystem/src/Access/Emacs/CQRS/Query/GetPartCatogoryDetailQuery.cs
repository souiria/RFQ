namespace Emacs.CQRS.Query
{
    public class GetPartCatogoryDetailQuery : IQuery<List<PartCategoryDetailGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
