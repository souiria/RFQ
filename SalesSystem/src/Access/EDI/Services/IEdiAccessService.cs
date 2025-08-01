namespace EDI.Services
{
    public interface IEdiAccessService
    {
        Task<ListEdiCustomerParameterGrpc> GetEdiCustomerParametersGrpcAsync(CancellationToken cancellationToken);
        Task<ListEdiFileDataUploadDuplicatesGrpc> GetEdiFileDataUploadDuplicatesGrpcAsync(CancellationToken cancellationToken);
        Task<ListEdiFileDataUploadGrpc> GetEdiFileDataUploadGrpcAsync(CancellationToken cancellationToken);
        Task<ListEdiGlobalParametersGrpc> GetEdiGlobalParametersGrpcAsync(CancellationToken cancellationToken);
        Task<ListEdiInvoiceInformationGrpc> GetEdiInvoiceInformationGrpcAsync(CancellationToken cancellationToken);
        Task<ListEdiInvoiceInformationDuplicatesGrpc> GetEdiInvoiceInformationDuplicatesGrpcAsync(CancellationToken cancellationToken);
        Task<ListEdiInvoiceUnit4Grpc> GetEdiInvoiceUnit4GrpcAsync(CancellationToken cancellationToken);
        Task<ListEdiZeroPriceExceptionsGrpc> GetEdiZeroPriceExceptionsGrpcAsync(CancellationToken cancellationToken);

        Task<bool> PopulateEdiCustomerParametersAsync(CancellationToken cancellationToken);
        Task<bool> PopulateEdiFileDataUploadDuplicatesGrpcAsync(CancellationToken cancellationToken);
        Task<bool> PopulateEdiFileDataUploadGrpcAsync(CancellationToken cancellationToken);
        Task<bool> PopulateEdiGlobalParametersGrpcAsync(CancellationToken cancellationToken);
        Task<bool> PopulateEdiInvoiceInformationGrpcAsync(CancellationToken cancellationToken);
        Task<bool> PopulateEdiInvoiceInformationDuplicatesGrpcAsync(CancellationToken cancellationToken);
        Task<bool> PopulateEdiInvoiceUnit4GrpcAsync(CancellationToken cancellationToken);
        Task<bool> PopulateEdiZeroPriceExceptionsGrpcAsync(CancellationToken cancellationToken);

    }
}
