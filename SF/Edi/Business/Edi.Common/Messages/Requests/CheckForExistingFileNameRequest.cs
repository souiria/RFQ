namespace Edi.Common.Messages.Requests;
public class CheckForExistingFileNameRequest : IRequest<List<EdiFileDataUploadDto>>
{
    public required string FileName { get; set; }
}
