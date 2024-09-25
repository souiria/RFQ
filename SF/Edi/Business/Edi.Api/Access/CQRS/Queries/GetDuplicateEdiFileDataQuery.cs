namespace Edi.Api.Access.CQRS.Queries;
internal class GetDuplicateEdiFileDataQuery : IRequest<List<EdiFileDataUploadDto>>
{
    public string Filename { get; set; }
    public DateTime DispatchDate { get; set; }
    public string DispatchNumber { get; set; }
}
