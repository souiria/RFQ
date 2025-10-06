namespace Rfq.Services
{
    public interface IAdssService
    {
        Task<(byte[]? ImageBytes, string? ContentType)> GetPartImageAsync(string partNumber, CancellationToken ct = default);
    }
}
