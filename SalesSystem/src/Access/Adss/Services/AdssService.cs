namespace Adss.Services
{
    public sealed class AdssService : IAdssService
    {
         readonly string _RootPath;
 
        readonly string _FallbackFileName;

        public AdssService(IConfiguration config)
        {
            _RootPath = config["Adss:RootPathLocal"] ?? throw new InvalidOperationException("Adss:RootPathLocal missing.");

            string[]? rawExtensions = config.GetSection("Adss:AllowedExtensions").Get<string[]>();
 
            _FallbackFileName = config["Adss:FallbackFileName"] ?? "noimage.jpg";
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

            // 2) Single fallback file (assumed noimage.jpg appsetting)
            string fallbackPath = Path.Combine(_RootPath, _FallbackFileName);
            if (File.Exists(fallbackPath))
            {
                byte[] bytes = await File.ReadAllBytesAsync(fallbackPath, ct);
                return (bytes, "image/jpeg");
            }

            // 3) Nothing found
            return (null, null);
        }
    }
}