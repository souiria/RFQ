using Ardalis.Specification;

namespace Edi.FileWatcher.Access.CQRS.Specifications;
internal class GetDuplicateEdiFileDataReadOnlySpec : Specification<DbEdiFileDataUpload>
{
    public GetDuplicateEdiFileDataReadOnlySpec(string? filename, DateTime? dispatchDate, string? dispatchNumber)
    {
        if (dispatchDate != DateTime.MinValue)
        {
            Query
                .Where(x => x.FileName != filename && x.DispatchDate == dispatchDate &&
                            x.DispatchNumber == dispatchNumber)
                .AsNoTracking();
        }
        else
        {
            Query
                .Where(x => x.FileName == filename && x.DispatchNumber == dispatchNumber)
                .AsNoTracking();
        }
    }
}
