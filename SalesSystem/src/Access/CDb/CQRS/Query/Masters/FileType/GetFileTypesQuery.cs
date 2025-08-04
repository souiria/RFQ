namespace CDb.CQRS.Query.Masters.FileType
{
    public class GetFileTypesQuery : IQuery<List<FileTypeGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
