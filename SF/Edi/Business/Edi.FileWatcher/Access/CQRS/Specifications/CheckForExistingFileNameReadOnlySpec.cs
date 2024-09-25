namespace Edi.FileWatcher.Access.CQRS.Specifications;
internal sealed class CheckForExistingFileNameReadOnlySpec : Specification<DbEdiFileDataUpload>
{
    public CheckForExistingFileNameReadOnlySpec(string fileName)
    {
        Query.Where(x => x.FileName == fileName).AsNoTracking();
    }
}
