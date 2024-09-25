namespace Edi.FileWatcher.Access.CQRS.Queries;
internal class GetDuplicateEdiFileDataQuery : IRequest<List<EdiFileDataUploadDto>>
{
    public required string Filename { get; set; }
    public DateTime DispatchDate { get; set; }
    public required string DispatchNumber { get; set; }
}
