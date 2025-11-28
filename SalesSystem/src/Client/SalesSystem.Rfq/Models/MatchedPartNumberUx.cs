using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesSystem.Rfq.Models
{
    public class MatchedPartNumberUx
    {
        public string? SewsePartNumber
        { get; set; }
        public PartImageData? PartImage
        { get; set; }
        public ReadOnlyCollection<NprSearchResult> NprSearchResults 
        { get; set; }
        public MatchedPartNumberUx()
        {
            List<NprSearchResult> partsData = new();
            SewsePartNumber = string.Empty;
            NprSearchResults = new ReadOnlyCollection<NprSearchResult>(partsData);
            PartImage = new PartImageData();
        }
    }

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

    public class NprSearchResult
    {
        public string? SewsePartNumber 
        { get; set; }
        public decimal? Price 
        { get; set; }
    }

    public class NprResultData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<Pending>")]
        public List<string> PartNumbers
        { get; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<Pending>")]
        public List<decimal> Prices 
        { get; }

        public NprResultData()
        {
            PartNumbers = new List<string>();
            Prices = new List<decimal>();
        }
    }
}
