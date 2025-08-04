namespace CDb.CQRS.Query
{
    public class GetFileNamesQuery : IQuery<List<FileNameGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
