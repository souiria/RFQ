namespace SalesSystem.Rfq.Models
{
    public class PartImageData
    {
        byte[] _ImageBytes;

        public IReadOnlyList<byte> ImageBytes
        {
            get => _ImageBytes;
            set => _ImageBytes = value?.ToArray() ?? Array.Empty<byte>();
        }

        public string MimeType
        { get; set; }

        public PartImageData()
        {
            _ImageBytes = Array.Empty<byte>();
            MimeType = "image/png";
        }
    }
}
