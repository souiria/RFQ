namespace SalesSystem.Rfq.Models
{
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
