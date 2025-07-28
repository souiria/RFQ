namespace CDb.CQRS.Query.ClipType
{
    public class GetClipTypesQuery : IQuery<List<ClipTypeGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
