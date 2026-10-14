using System.Diagnostics;

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
            _Logger.GenericLogInformation(information: $"Using root path: {_RootPath}");
            if (string.IsNullOrWhiteSpace(_RootPath))
            {
                _Logger.GenericLogInformation(information: $"Root path configuration is missing.");
                throw new InvalidOperationException("Root path configuration is missing.");
            }            
        }

        public async Task<(byte[]? ImageBytes, string? ContentType)> GetPartImageAsync(
     string partNumber,
     CancellationToken ct = default)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            _Logger.GenericLogInformation(
                $"ADSS FILE START - Part {partNumber}, " +
                $"RootPath {_RootPath}");

            if (string.IsNullOrWhiteSpace(partNumber))
            {
                _Logger.GenericLogInformation(
                    "ADSS FILE EMPTY PART");

                return (null, null);
            }

            string candidate = Path.Combine(_RootPath, partNumber + ".jpg");

            _Logger.GenericLogInformation(
                $"ADSS FILE BEFORE EXISTS - Path {candidate}");

            bool imageExists = File.Exists(candidate);

            _Logger.GenericLogInformation(
                $"ADSS FILE AFTER EXISTS - Path {candidate}, " +
                $"Exists {imageExists}, " +
                $"ElapsedMs {sw.ElapsedMilliseconds}");

            if (imageExists)
            {
                _Logger.GenericLogInformation(
                    $"ADSS FILE BEFORE READ - Path {candidate}");

                byte[] bytes = await File.ReadAllBytesAsync(candidate, ct);

                _Logger.GenericLogInformation(
                    $"ADSS FILE AFTER READ - Path {candidate}, " +
                    $"Bytes {bytes.Length}, " +
                    $"ElapsedMs {sw.ElapsedMilliseconds}");

                return (bytes, "image/jpeg");
            }

            if (8 < partNumber.Length &&
                partNumber.EndsWith("00", StringComparison.InvariantCulture))
            {
                string shortName = partNumber.Substring(0, partNumber.Length - 2);
                candidate = Path.Combine(_RootPath, shortName + ".jpg");

                _Logger.GenericLogInformation(
                    $"ADSS FILE BEFORE SHORT EXISTS - Path {candidate}");

                bool shortImageExists = File.Exists(candidate);

                _Logger.GenericLogInformation(
                    $"ADSS FILE AFTER SHORT EXISTS - Path {candidate}, " +
                    $"Exists {shortImageExists}, " +
                    $"ElapsedMs {sw.ElapsedMilliseconds}");

                if (shortImageExists)
                {
                    _Logger.GenericLogInformation(
                        $"ADSS FILE BEFORE SHORT READ - Path {candidate}");

                    byte[] bytes = await File.ReadAllBytesAsync(candidate, ct);

                    _Logger.GenericLogInformation(
                        $"ADSS FILE AFTER SHORT READ - Path {candidate}, " +
                        $"Bytes {bytes.Length}, " +
                        $"ElapsedMs {sw.ElapsedMilliseconds}");

                    return (bytes, "image/jpeg");
                }
            }

            _Logger.GenericLogInformation(
                $"ADSS FILE NOT FOUND - Part {partNumber}, " +
                $"ElapsedMs {sw.ElapsedMilliseconds}");

            return (null, null);
        }

    }
}