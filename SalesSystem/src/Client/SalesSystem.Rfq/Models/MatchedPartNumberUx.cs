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
}
