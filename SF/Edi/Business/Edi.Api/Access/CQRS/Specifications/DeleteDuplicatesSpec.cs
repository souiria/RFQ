namespace Edi.Api.Access.CQRS.Specifications;

internal sealed class DeleteDuplicatesSpec : Specification<DbEdiFileDataUploadDuplicate>
{
    public DeleteDuplicatesSpec(string? filename, string? dispatchno)
    {
        Query
            .Where(x => x.FileName == filename && x.DispatchNumber == dispatchno);
    }
}