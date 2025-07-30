namespace CDb.CQRS.Query.FileType
{
    public class GetFileTypesQuery : IQuery<List<FileTypeGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
