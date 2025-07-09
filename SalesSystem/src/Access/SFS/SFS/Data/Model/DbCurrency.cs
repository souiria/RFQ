
namespace SFS.Data.Model
{
    public class DbCurrency : IAggregateRoot
    {
        public int Id 
        { get; set; }
        public string? Profile 
        { get; set; }
        public string? CurrCode 
        { get; set; }
        public string? Description
        { get; set; }
        public DateTime UpdatedDate 
        { get; set; }
        public string? UpdatedBy
        { get; set; }
    }
}
