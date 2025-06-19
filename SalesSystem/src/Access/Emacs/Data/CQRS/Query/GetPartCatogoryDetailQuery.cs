namespace Emacs.Data.CQRS.Query
{
    public class GetPartCatogoryDetailQuery : IQuery<List<PartCategoryDetailData>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
