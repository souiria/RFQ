
namespace SFS.Data.Model
{
    public class DbCustomerNonWorkingDays : IAggregateRoot
    {
        public string? Profile 
        { get; set; }
        //public int Year
        //{ get; set; }
        public string? DelPoint 
        { get; set; }
        public string? NonWorkingDay 
        { get; set; }
        public DateTime UpdatedDate 
        { get; set; }
        public string? UpdatedBy 
        { get; set; }
        //public int State
        //{ get; set; }
    }
}
