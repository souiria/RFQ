namespace SalesSystem.Rfq.Models
{
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
}
