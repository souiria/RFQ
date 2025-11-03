
namespace Adss.Services
{
    public class AdssService : IAdssService
    {
        readonly string _RootPath;
        readonly ILogger<AdssService> _Logger;

        public AdssService( IOptions<AdssSettings> options, IHostEnvironment env, ILogger<AdssService> logger)
        {
            _Logger = logger;
            AdssSettings settings = options.Value;

            // Use local path in Development, otherwise use server path
                    _RootPath = env.IsDevelopment()
                ? settings.RootPathLocal
                : settings.RootPathServer;
            Console.WriteLine($"Using root path: {_RootPath}");
            if (string.IsNullOrWhiteSpace(_RootPath))
            {
                _Logger.GenericLogInformation(information: $"Root path configuration is missing.");
                throw new InvalidOperationException("Root path configuration is missing.");
            }            
        }

        public async Task<(byte[]? ImageBytes, string? ContentType)> GetPartImageAsync( string partNumber, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(partNumber))
            {
            _Logger.GenericLogInformation(information: $"Part number is null or empty."); 
            return (null, null);
            }
            // 1) Try exact JPG for the part number (no loops, no other extensions)
            string candidate = Path.Combine(_RootPath, partNumber + ".jpg");
            if (File.Exists(candidate))
            {
            _Logger.GenericLogInformation(information: $"Found image for part number {partNumber} at {candidate}");
            byte[] bytes = await File.ReadAllBytesAsync(candidate, ct);
                return (bytes, "image/jpeg");
            }
            // 2) Nothing found
        return (null, null);
        }
    }
}