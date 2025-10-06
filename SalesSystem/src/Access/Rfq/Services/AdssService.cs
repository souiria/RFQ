using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace Rfq.Services
{
    public sealed class AdssService : IAdssService
    {
         readonly string _RootPath;
         readonly string[] _Exts;

         static readonly Dictionary<string, string> _MimeByExt;
         static readonly Regex _SafePart;

        static AdssService()
        {
            _MimeByExt = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            _MimeByExt[".jpg"] = "image/jpeg";
            _MimeByExt[".jpeg"] = "image/jpeg";
            _MimeByExt[".png"] = "image/png";

            _SafePart = new Regex(@"^[A-Za-z0-9._-]+$", RegexOptions.Compiled);
        }

        public AdssService(IConfiguration config)
        {
            _RootPath = config["Adss:RootPathLocal"] ?? throw new InvalidOperationException("Adss:RootPathLocal missing.");

            string[]? rawExtensions = config.GetSection("Adss:AllowedExtensions").Get<string[]>();
            string[] allowedExtensions = rawExtensions ?? new[] { ".jpg" };

            List<string> normalizedExts = new List<string>();
            foreach (string ext in allowedExtensions)
            {
                string normalized = ext.StartsWith('.') ? ext : "." + ext;
                normalizedExts.Add(normalized);
            }

            _Exts = normalizedExts.ToArray();
        }

        public async Task<(byte[]? ImageBytes, string? ContentType)> GetPartImageAsync(
            string partNumber,
            CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(partNumber))
            {
                return (null, null);
            }

            bool isSafe = _SafePart.IsMatch(partNumber);
            if (!isSafe)
            {
                return (null, null);
            }

            foreach (string ext in _Exts)
            {
                string candidate = Path.Combine(_RootPath, partNumber + ext);
                bool exists = File.Exists(candidate);
                if (exists)
                {
                    await using FileStream fs = File.OpenRead(candidate);
                    using MemoryStream ms = new MemoryStream();
                    await fs.CopyToAsync(ms, ct);
                    byte[] bytes = ms.ToArray();

                    bool found = _MimeByExt.TryGetValue(ext, out string? ctVal);
                    string contentType = found ? ctVal! : "application/octet-stream";

                    return (bytes, contentType);
                }
            }

            return (null, null);
        }
    }
}
