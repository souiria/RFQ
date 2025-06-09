namespace Emacs.Data.CQRS.Query
{
    public class GetPartCatogoryDetailQuery : IQuery<List<PartCategoryDetailDto>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
