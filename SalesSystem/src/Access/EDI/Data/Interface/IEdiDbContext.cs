namespace EDI.Data.Interface
{
    public interface IEdiDbContext
    {
        DbSet<DbEdiFileDataUpload> EdiFileDataUploads
        { get; }
        DbSet<DbEdiFileDataUploadDuplicate> EdiFileDataUploadDuplicates
        { get; }
        DbSet<DbEdiInvoiceInformation> EdiInvoiceInformation
        { get; }
        DbSet<DbEdiCustomerParameter> EdiCustomerParameters
        { get; }
        DbSet<DbEdiGlobalParameter> EdiGlobalParameters
        { get; }
        DbSet<DbZeroPriceExceptions> ZeroPriceExceptions
        { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
