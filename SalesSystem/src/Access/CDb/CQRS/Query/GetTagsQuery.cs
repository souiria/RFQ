namespace CDb.CQRS.Query
{
    public class GetTagsQuery : IQuery<List<TagGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
