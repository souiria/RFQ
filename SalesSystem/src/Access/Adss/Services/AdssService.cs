namespace Adss.Services
{
    public class AdssService : IAdssService
    {
         readonly string _RootPath;
        public AdssService(IConfiguration config)
        {
                #if DEBUG
                            const string rootKey = "Adss:RootPathLocal";
                #else
                    const string rootKey = "Adss:RootPathServer";
                #endif

            _RootPath = config[rootKey]
                ?? throw new InvalidOperationException($"{rootKey} missing.");

        }

       public async Task<(byte[]? ImageBytes, string? ContentType)> GetPartImageAsync( string partNumber, CancellationToken ct = default)
        {
                if (string.IsNullOrWhiteSpace(partNumber))
                {
                    return (null, null);
                }

                // 1) Try exact JPG for the part number (no loops, no other extensions)
                string candidate = Path.Combine(_RootPath, partNumber + ".jpg");
                if (File.Exists(candidate))
                {
                    byte[] bytes = await File.ReadAllBytesAsync(candidate, ct);
                    return (bytes, "image/jpeg");
                }

                // 2) Nothing found
            return (null, null);
        }
    }
}