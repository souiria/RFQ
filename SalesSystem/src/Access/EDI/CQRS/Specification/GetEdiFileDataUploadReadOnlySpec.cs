namespace EDI.CQRS.Specification
{
    public class GetEdiFileDataUploadReadOnlySpec : Specification<DbEdiFileDataUpload>
    {
        public GetEdiFileDataUploadReadOnlySpec()
        {
            Query
                .AsNoTracking();
        }
    }
}
