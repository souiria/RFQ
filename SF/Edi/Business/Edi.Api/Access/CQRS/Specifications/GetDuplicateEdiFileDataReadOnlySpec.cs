namespace Edi.Api.Access.CQRS.Specifications;
internal sealed class GetDuplicateEdiFileDataReadOnlySpec : Specification<DbEdiFileDataUploadDuplicate>
{
    public GetDuplicateEdiFileDataReadOnlySpec(string? filename, DateTime? dispatchDate, string? dispatchNumber)
    {
        if (dispatchDate != DateTime.MinValue)
        {
            Query
                .Where(x => x.FileName != filename && x.DispatchDate == dispatchDate &&
                            x.DispatchNumber == dispatchNumber && x.Status == EdiFileUploadStatus.Pending)
                .AsNoTracking();
        }
        else if (filename!=null)
        {
            Query
                .Where(x => x.FileName == filename && x.DispatchNumber == dispatchNumber && x.Status == EdiFileUploadStatus.Pending)
                .AsNoTracking();
        }
        else
        {
            Query
                .Where(x => x.Status == EdiFileUploadStatus.Pending)
                .AsNoTracking();
        }
    }
}
