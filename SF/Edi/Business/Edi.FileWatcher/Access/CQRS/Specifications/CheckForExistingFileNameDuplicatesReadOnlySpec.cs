namespace Edi.FileWatcher.Access.CQRS.Specifications;
internal sealed class CheckForExistingFileNameDuplicatesReadOnlySpec : Specification<DbEdiFileDataUploadDuplicate>
{
    public CheckForExistingFileNameDuplicatesReadOnlySpec(string fileName)
    {
        Query.Where(x => x.FileName == fileName).AsNoTracking();
    }
}
