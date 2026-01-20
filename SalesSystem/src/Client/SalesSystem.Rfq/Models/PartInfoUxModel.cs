namespace SalesSystem.Rfq.Models
{
    public class PartInfoUxModel
    {
        public PartInfoUxModel(string partNumber)
        {
            PartNumber = partNumber;
        }

        public string PartNumber 
        { get; }
    }
}