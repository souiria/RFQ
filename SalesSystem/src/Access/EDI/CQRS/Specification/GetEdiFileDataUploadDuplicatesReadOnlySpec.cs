namespace EDI.CQRS.Specification
{
    public class GetEdiFileDataUploadDuplicatesReadOnlySpec : Specification<DbEdiFileDataUploadDuplicate>
    {
        public GetEdiFileDataUploadDuplicatesReadOnlySpec()
        {
            Query
                .AsNoTracking();
        }
    }
}
