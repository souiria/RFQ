
namespace SFS.Data.Model
{
    public  class DbCustomer : IAggregateRoot
    {
        public int Id 
        { get; set; }
        public string? Profile 
        { get; set; }
        public string? CustCode 
        { get; set; }
        public string? CustName 
        { get; set; }
        public string? CustType 
        { get; set; }
        public string? ApplyCuAdj 
        { get; set; }
        public DateTime UpdatedDate 
        { get; set; }
        public string? UpdatedBy
        { get; set; }
    }
}
