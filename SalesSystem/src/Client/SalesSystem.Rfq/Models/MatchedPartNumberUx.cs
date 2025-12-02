using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesSystem.Rfq.Models
{
    public class MatchedPartNumberUx
    {
        public int Index 
        { get; set; }
        public bool IsExactMatch
        { get; set; }
        public string? SewsePartNumber
        { get; set; }
        public PartImageData? PartImage
        { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<Pending>")]
        public List<NprSearchResult> NprSearchResults 
        { get; }
        public bool HasImage => PartImage != null && 0 <= PartImage.ImageBytes.Count;
        public MatchedPartNumberUx()
        {
            IsExactMatch = false;
            SewsePartNumber = string.Empty;
            NprSearchResults = new List<NprSearchResult>();
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

        public NprSearchResult()
        {
            SewsePartNumber = string.Empty;
            Price = 0;
        }
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
