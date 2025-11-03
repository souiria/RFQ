namespace Adss.Services
{
    public interface IAdssService
    {
        Task<(byte[]? ImageBytes, string? ContentType)> GetPartImageAsync(string partNumber, CancellationToken ct = default);

        //Task<FilterImageResponse> FilterImagesAsync(FilterImageRequest request, CancellationToken ct = default);
    }
}
