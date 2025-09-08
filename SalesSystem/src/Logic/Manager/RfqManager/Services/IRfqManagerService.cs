namespace RfqModule.Services
{
    public interface IRfqManagerService
    {
        Task<FileUploadResponse> UploadFileAsync(FileUploadRequest request);
    }
}
